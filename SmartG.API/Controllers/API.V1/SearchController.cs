using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.DTOs;
using SmartG.Shared.RequestFeatures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartG.API.Controllers.API.V1
{
    [Route("api/search")]
    public class SearchController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SearchController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] RequestParameters requestParameters)
        {
            var postParameters = new PostParameters
            {
                SearchTerm = requestParameters.SearchTerm,
                PageNumber=requestParameters.PageNumber,
                PageSize=requestParameters.PageSize
                
            };
            var pageParameters = new PageParameters
            {
                SearchTerm = requestParameters.SearchTerm,
                PageNumber = requestParameters.PageNumber,
                PageSize = requestParameters.PageSize

            };

            var portfolios = await _repository.Portfolio.GetAllPortfoliosAsync(requestParameters,trackChanges: false);
            var services = await _repository.Service.GetServicesAsync(requestParameters, false);
            var posts = await _repository.Post.GetAllPostsAsync(postParameters, false);
            var pages = await _repository.Page.GetAllPagesAsync(pageParameters, false);
            var results = new SearchDto();

            var postsToReturn = _mapper.Map<ICollection<PostDto>>(posts);

            foreach (var post in postsToReturn)
            {
                Category category;
                Image image;

                if (post.SgCategoryId != null)
                {


                    category = await _repository.Category.GetCategoryByIdAsync((int)post.SgCategoryId, trackChanges: false);
                    post.Category = _mapper.Map<CategoryDto>(category);
                }
                if (post.SgImageId != null)
                {
                    image = await _repository.Image.GetImageByIdAsync((int)post.SgImageId, trackChanges: false);
                    post.Image = _mapper.Map<ImageDto>(image);
                }
                Gallery gallery;
                if (post.SgGalleryId != null)
                {
                    gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
                    post.Gallery = _mapper.Map<GalleryDto>(gallery);
                }
            }
                var portfolioToReturn = _mapper.Map<ICollection<PortfolioDto>>(portfolios);
            foreach (var post in portfolioToReturn)
            {
                Category category;
                Image image;

                if (post.SgCategoryId != null)
                {


                    category = await _repository.Category.GetCategoryByIdAsync((int)post.SgCategoryId, trackChanges: false);
                    post.Category = _mapper.Map<CategoryDto>(category);
                }
                if (post.SgImageId != null)
                {
                    image = await _repository.Image.GetImageByIdAsync((int)post.SgImageId, trackChanges: false);
                    post.Image = _mapper.Map<ImageDto>(image);
                }
                Gallery gallery;
                if (post.SgGalleryId != null)
                {
                    gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
                    post.Gallery = _mapper.Map<GalleryDto>(gallery);
                }
            }

            var pageToReturn = _mapper.Map<ICollection<PageDto>>(pages);
            foreach (var post in pageToReturn)
            {

                Image image;


                if (post.SgImageId != null)
                {
                    image = await _repository.Image.GetImageByIdAsync((int)post.SgImageId, trackChanges: false);
                    post.Image = _mapper.Map<ImageDto>(image);
                }
                Gallery gallery;
                if (post.SgGalleryId != null)
                {
                    gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
                    post.Gallery = _mapper.Map<GalleryDto>(gallery);
                }
            }

            var serviceToReturn = _mapper.Map<ICollection<ServiceDto>>(services);
            foreach (var post in serviceToReturn)
            {

                Image image;


                if (post.SgImageId != null)
                {
                    image = await _repository.Image.GetImageByIdAsync((int)post.SgImageId, trackChanges: false);
                    post.Image = _mapper.Map<ImageDto>(image);
                }
                Gallery gallery;
                if (post.SgGalleryId != null)
                {
                    gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
                    post.Gallery = _mapper.Map<GalleryDto>(gallery);
                }
            }

            results.Portfolios = portfolioToReturn;
            results.Pages = pageToReturn;
            results.Services = serviceToReturn;
            results.Posts = postsToReturn;


            return Ok(results);
        }

       
    }
}

