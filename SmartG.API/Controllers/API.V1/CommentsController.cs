using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartG.API.ActionFilters;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.DTOs;
using SmartG.Shared.RequestFeatures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartG.API.Controllers.API.V1
{

    [Route("api/{postType}/comments")]

    public class CommentsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CommentsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet("type-id/{postId}")]
        public async Task<IActionResult> GetComments([FromQuery] CommentParameters commentParameters,Guid
            postId, string postType)
        {
            var postTypeValues = Enum.GetNames(typeof(PostTypeEnum));
            if (!postTypeValues.Contains(postType))
            {
                return NotFound($"Postype {postType} does not exist");
            }
            var comments = await _repository.Comment.GetAllCommentsForPostAsync(commentParameters,postId,postType, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(comments.MetaData));
            var commentsToReturn = _mapper.Map<IEnumerable<CommentDto>>(comments);
            return Ok(commentsToReturn);
        }

        // GET api/values/5
        [HttpGet("{commentId}", Name = "commentsId")]
        public async Task<IActionResult> GetCommentById(int commentId)
        {
            
            var comment = await _repository.Comment.GetCommentByIdAsync(commentId, trackChanges: false);
            if (comment is null)
                return NotFound();
            var commentToReturn = _mapper.Map<CommentDto>(comment);
            return Ok(commentToReturn);
        }




        [HttpPost("{postId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateComment([FromBody] CommentForCreationDto comment, Guid postId, string postType)
        {

            var postTypeValues = Enum.GetNames(typeof(PostTypeEnum));
            if (!postTypeValues.Contains(postType))
            {
                return NotFound($"Postype {postType} does not exist");
            }
            if (postType.Equals(PostTypeEnum.portfolio.ToString()) )
            {
                comment.PortfolioId = postId;
                var postFromDb = await _repository.Portfolio.GetPortfolioByIdAsync(postId, trackChanges: false);
                if (postFromDb is null)
                {
                    return NotFound($" Portfolio with id {postId} not found");
                }
            }
            else if (postType.Equals(PostTypeEnum.post.ToString()))
            {
                comment.PostId = postId;
                var postFromDb = await _repository.Post.GetPostByIdAsync(postId, trackChanges: false);
                if (postFromDb is null)
                {
                    return NotFound($" post with id {postId} not found");
                }
            }else
            {
                return NotFound($" Post Type {postType} does not exist");
            }
           
                  
            
            var commentEntity = _mapper.Map<Comment>(comment);
            _repository.Comment.CreateCommentAsync(commentEntity);
            await _repository.SaveAsync();
            var commentToReturn = _mapper.Map<CommentDto>(commentEntity);

            return CreatedAtRoute("commentsId", new { commentId = commentToReturn.CommentId ,postType=postType}, commentToReturn);
        }



        [HttpPut("{commentId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCommentById(int commentId, [FromBody] CommentForUpdateDto comment)
        {
            
            var commentEntity = await _repository.Comment.GetCommentByIdAsync(commentId, trackChanges: true);
            if (commentEntity is null)
                return NotFound($"Comment with id {commentId} does not exist");



            _mapper.Map(comment, commentEntity);

            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
         
            var commentEntity = await _repository.Comment.GetCommentByIdAsync(commentId: commentId, trackChanges: false);
            if (commentEntity is null)
                return NotFound($"Comment with id {commentId} does not exist");



            _repository.Comment.DeleteCommentAsync(commentEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

       
    }
}

