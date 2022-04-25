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

    [Route("api/{postId}/comments")]

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
        [HttpGet]
        public async Task<IActionResult> GetComments([FromQuery] CommentParameters commentParameters,int postId)
        {

            var comments = await _repository.Comment.GetAllCommentsForPostAsync(commentParameters,postId, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(comments.MetaData));
            var commentsToReturn = _mapper.Map<IEnumerable<CommentDto>>(comments);
            return Ok(commentsToReturn);
        }

        // GET api/values/5
        [HttpGet("{commentId}", Name = "commentsId")]
        public async Task<IActionResult> GetCommentById(int commentId,int postId)
        {
            var postFromDb = await _repository.Post.GetPostByIdAsync(postId, trackChanges: false);
            if (postFromDb is null)
            {
                return NotFound($" post with id {postId} not found");
            }
            var comment = await _repository.Comment.GetCommentByIdAsync(commentId, trackChanges: false);
            if (comment is null)
                return NotFound();
            var commentToReturn = _mapper.Map<CommentDto>(comment);
            return Ok(commentToReturn);
        }




        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateComment([FromBody] CommentForCreationDto comment, int postId)
        {
            var postFromDb = await _repository.Post.GetPostByIdAsync(postId, trackChanges: false);
            if(postFromDb is null)
            {
                return NotFound($" post with id {postId} not found");
            }
                  

            var commentEntity = _mapper.Map<Comment>(comment);
            _repository.Comment.CreateCommentAsync(commentEntity);
            await _repository.SaveAsync();
            var commentToReturn = _mapper.Map<CommentDto>(commentEntity);

            return CreatedAtRoute("commentsId", new { commentId = commentToReturn.CommentId, postId= postId }, commentToReturn);
        }



        [HttpPut("{commentId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCommentById(int commentId, [FromBody] CommentForUpdateDto comment, int postId)
        {
            var postFromDb = await _repository.Post.GetPostByIdAsync(postId, trackChanges: false);
            if (postFromDb is null)
            {
                return NotFound($" post with id {postId} not found");
            }
            var commentEntity = await _repository.Comment.GetCommentByIdAsync(commentId, trackChanges: true);
            if (commentEntity is null)
                return NotFound($"Comment with id {commentId} does not exist");



            _mapper.Map(comment, commentEntity);

            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId,int postId)
        {
            var postFromDb = await _repository.Post.GetPostByIdAsync(postId, trackChanges: false);
            if (postFromDb is null)
            {
                return NotFound($" post with id {postId} not found");
            }

            var commentEntity = await _repository.Comment.GetCommentByIdAsync(commentId: commentId, trackChanges: false);
            if (commentEntity is null)
                return NotFound($"Comment with id {commentId} does not exist");



            _repository.Comment.DeleteCommentAsync(commentEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

       
    }
}

