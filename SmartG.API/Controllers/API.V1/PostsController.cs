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
    [Route("api/posts")]

    public class PostsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PostsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
        public async Task<IActionResult> GetPageById(int postId)
        {
            var post = await _repository.Post.GetPostByIdAsync(postId, trackChanges: false);
            if (post is null)
                return NotFound();
            var postToReturn = _mapper.Map<PostDto>(post);
            return Ok(postToReturn);
        }




        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePost([FromBody] PostForCreationDto post)
        {
            var postsFromDb = await _repository.Post.GetPostBySlugNameAsync(post.Slug, trackChanges: false);

            if (postsFromDb != null)
            {
                post.Slug += "-copy";
            }


            var postEntity = _mapper.Map<Post>(post);
            _repository.Post.CreatePostAsync(postEntity);
            await _repository.SaveAsync();
            var postToReturn = _mapper.Map<PostDto>(postEntity);

            //var votesToReturn = await _serviceManager.QualificationService.CreateQualificationForStudyOptionAsync(studyOptionId, qualification, trackChanges: false);
            return CreatedAtRoute("postsId", new { postId = postToReturn.PostId }, postToReturn);
        }



        [HttpPut("{postId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePostById(int postId, [FromBody] PostForUpdateDto post)
        {

            var postEntity = await _repository.Post.GetPostByIdAsync(postId, trackChanges: true);
            if (postEntity is null)
                return NotFound($"Post with id {postId} does not exist");



            _mapper.Map(post, postEntity);

            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
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

