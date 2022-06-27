using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartG.Contracts;
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
            var portfolioToReturn = _mapper.Map<ICollection<PortfolioDto>>(portfolios);
            var pageToReturn = _mapper.Map<ICollection<PageDto>>(pages);
            var serviceToReturn = _mapper.Map<ICollection<ServiceDto>>(services);

            results.Portfolios = portfolioToReturn;
            results.Pages = pageToReturn;
            results.Services = serviceToReturn;
            results.Posts = postsToReturn;


            return Ok(results);
        }

       
    }
}

