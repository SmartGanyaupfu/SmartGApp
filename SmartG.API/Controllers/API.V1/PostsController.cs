using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartG.API.ActionFilters;
using SmartG.API.Extensions;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.DTOs;
using SmartG.Shared.RequestFeatures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartG.API.Controllers.API.V1
{
    [Route("api/posts")]

    public class PostsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IImageUploader _imageService;

        public PostsController(IRepositoryManager repository, IMapper mapper, IImageUploader imageService)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery] PostParameters postParameters)
        {

            var posts = await _repository.Post.GetAllPostsAsync (postParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(posts.MetaData));
            var postsToReturn = _mapper.Map<IEnumerable<PostDto>>(posts);
            return Ok(postsToReturn);
        }

        // GET api/values/5
        [HttpGet("{postId}", Name = "postsId")]
        public async Task<IActionResult> GetPageById(Guid postId)
        {
            var post = await _repository.Post.GetPostByIdAsync(postId, trackChanges: false);
            if (post is null)
                return NotFound();
            var postToReturn = _mapper.Map<PostDto>(post);
            return Ok(postToReturn);
        }
        [HttpGet("slug/{postSlug}")]
        public async Task<IActionResult> GetPostBySlug(string postSlug)
        {
            var post = await _repository.Post.GetPostBySlugNameAsync(postSlug, trackChanges: false);
            if (post is null)
                return NotFound();
            var pageToReturn = _mapper.Map<PostDto>(post);
            return Ok(pageToReturn);
        }
        /*[Authorize]
        [HttpPost("{postId}/add-image")]
        public async Task<IActionResult> AddImage(IFormFile file, Guid postId)
        {
            var postEntity = await _repository.Post.GetPostByIdAsync(postId, trackChanges: true);
            if (postEntity is null)
                return NotFound($"post with id {postEntity} does not exist");

            var result = await _imageService.AddImageAsync(file);
            if (result.Error != null)
                return BadRequest(result.Error.Message);

            var image = new Image()
            {
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Deleted = false,
                PublicId = result.PublicId,
                ImageUrl = result.SecureUrl.AbsoluteUri
            };
            postEntity.Image = image;

            await _repository.SaveAsync();

            var postToReturn = _mapper.Map<PostDto>(postEntity);


            return CreatedAtRoute("postsId", new { postId = postToReturn.PostId }, postToReturn);
        }*/

        [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePost([FromBody] PostForCreationDto post)
        {
            var postsFromDb = await _repository.Post.GetPostBySlugNameAsync(post.Slug, trackChanges: false);

            if (postsFromDb != null)
            {
                post.Slug += "-copy";
            }

            post.AuthorId = User.GetUserId();

            var postEntity = _mapper.Map<Post>(post);
            _repository.Post.CreatePostAsync(postEntity);
            await _repository.SaveAsync();
            var postToReturn = _mapper.Map<PostDto>(postEntity);

            //var votesToReturn = await _serviceManager.QualificationService.CreateQualificationForStudyOptionAsync(studyOptionId, qualification, trackChanges: false);
            return CreatedAtRoute("postsId", new { PostId = postToReturn.PostId }, postToReturn);
        }
        [Authorize]
        [HttpPost("{postId}/add-block")]
        public async Task<IActionResult> AddBlock([FromBody] ContentBlockForCreationDto contentBlock, Guid postId)
        {
            var postEntity = await _repository.Post.GetPostByIdAsync(postId, trackChanges: false);
            if (postEntity is null)
                return NotFound($"Post with id {postId} does not exist.");

            var blockEntity = _mapper.Map<ContentBlock>(contentBlock);
            _repository.ContentBlock.CreateContentBlockAsync(blockEntity);

            await _repository.SaveAsync();

            var postToReturn = _mapper.Map<PostDto>(postEntity);


            return CreatedAtRoute("postsId", new { postId = postToReturn.PostId }, postToReturn);
        }

        [Authorize]
        [HttpPut("{postId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePostById(Guid postId, [FromBody] PostForUpdateDto post)
        {
            var postFromDb = await _repository.Post.GetPostBySlugNameAsync(post.Slug, trackChanges: false);

            if (postFromDb != null && postFromDb.PostId !=postId)
            {
                post.Slug += "-copy";
            }
            post.AuthorId = User.GetUserId();

            var postEntity = await _repository.Post.GetPostByIdAsync(postId, trackChanges: true);
            if (postEntity is null)
                return NotFound($"Post with id {postId} does not exist");



            _mapper.Map(post, postEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(Guid postId)
        {


            var postEntity = await _repository.Post.GetPostByIdAsync(postId: postId, trackChanges: false);
            if (postEntity is null)
                return NotFound($"Post with id {postId} does not exist");




            _repository.Post.DeletePostAsync(postEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}

