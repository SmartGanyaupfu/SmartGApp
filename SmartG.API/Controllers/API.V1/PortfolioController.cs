using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SmartG.API.ActionFilters;
using SmartG.API.Extensions;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.DTOs;
using SmartG.Shared.RequestFeatures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartG.API.Controllers.API.V1
{
    [Route("api/portfolios")]

    public class PortfolioController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IImageUploader _imageService;

        public PortfolioController(IRepositoryManager repository, IMapper mapper, IImageUploader imageService)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetPortfolios([FromQuery] RequestParameters requestParameters)
        {

            var portfolios = await _repository.Portfolio.GetAllPortfoliosAsync(requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(portfolios.MetaData));
            var portfoliosToReturn = _mapper.Map<IEnumerable<PortfolioDto>>(portfolios);

            foreach (var post in portfoliosToReturn)
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
                return Ok(portfoliosToReturn);
        }
        // GET api/values/5
        [HttpGet("{portfolioId}", Name = "portfoliosId")]
        public async Task<IActionResult> GetPortfolioById(Guid portfolioId)
        {
            var portfolio = await _repository.Portfolio.GetPortfolioByIdAsync(portfolioId, trackChanges: false);
            if (portfolio is null)
                return NotFound();
            var portfolioToReturn = _mapper.Map<PortfolioDto>(portfolio);

            int catId;

            Category category;
            Image image;
            if (portfolio.SgCategoryId != null)
            {
                catId = (int)portfolio.SgCategoryId;

                category = await _repository.Category.GetCategoryByIdAsync(catId, trackChanges: false);
                portfolioToReturn.Category = _mapper.Map<CategoryDto>(category);
            }
            if (portfolio.SgImageId != null)
            {
                image = await _repository.Image.GetImageByIdAsync((int)portfolio.SgImageId, trackChanges: false);
                portfolioToReturn.Image = _mapper.Map<ImageDto>(image);
            }
            Gallery gallery;
            if (portfolio.SgGalleryId != null)
            {
                gallery = await _repository.Gallery.GetGalleryByIdAsync((int)portfolio.SgGalleryId, trackChanges: false);
                portfolioToReturn.Gallery = _mapper.Map<GalleryDto>(gallery);
            }

            return Ok(portfolioToReturn);
        }

        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> GetPortfolioBySlug(string slug)
        {
            var portfolio = await _repository.Portfolio.GetPortfolioBySlugNameAsync(slug, trackChanges: false);
            if (portfolio is null)
                return NotFound();
            var portfolioToReturn = _mapper.Map<PortfolioDto>(portfolio);


            int catId;

            Category category;
            Image image;
            if (portfolio.SgCategoryId != null)
            {
                catId = (int)portfolio.SgCategoryId;

                category = await _repository.Category.GetCategoryByIdAsync(catId, trackChanges: false);
                portfolioToReturn.Category = _mapper.Map<CategoryDto>(category);
            }
            if (portfolio.SgImageId != null)
            {
                image = await _repository.Image.GetImageByIdAsync((int)portfolio.SgImageId, trackChanges: false);
                portfolioToReturn.Image = _mapper.Map<ImageDto>(image);
            }
            Gallery gallery;
            if (portfolio.SgGalleryId != null)
            {
                gallery = await _repository.Gallery.GetGalleryByIdAsync((int)portfolio.SgGalleryId, trackChanges: false);
                portfolioToReturn.Gallery = _mapper.Map<GalleryDto>(gallery);
            }

            return Ok(portfolioToReturn);
        }

        [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePortfolio([FromBody] PortfolioForCreationDto portfolio)
        {
            var portfolioFromDb = await _repository.Portfolio.GetPortfolioBySlugNameAsync(portfolio.Slug, trackChanges: false);

            if (portfolioFromDb != null)
            {
                portfolio.Slug += "-copy";
            }
            portfolio.AuthorId = User.GetUserId();

            var portfolioEntity = _mapper.Map<Portfolio>(portfolio);
            _repository.Portfolio.CreatePortfolioAsync(portfolioEntity);
            await _repository.SaveAsync();
            var portfolioToReturn = _mapper.Map<PortfolioDto>(portfolioEntity);

            return CreatedAtRoute("portfoliosId", new { portfolioId = portfolioToReturn.PortfolioId }, portfolioToReturn);
        }
       /* [Authorize]
        [HttpPost("{portfolioId}/add-image")]
        public async Task<IActionResult> AddImage(IFormFile[] files, Guid portfolioId)
        {
            var portfolioEntity = await _repository.Portfolio.GetPortfolioByIdAsync( portfolioId, trackChanges: true);
            if (portfolioEntity is null)
                return NotFound($"page with id {portfolioEntity} does not exist");

            var results = await _imageService.AddImageAsync(files);
            foreach (var result in results)
            {
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
                
                portfolioEntity.Images?.Add(image);
            }
          

            await _repository.SaveAsync();

            var portfolioToReturn = _mapper.Map<PortfolioDto>(portfolioEntity);


            return CreatedAtRoute("portfoliosId", new { portfolioId = portfolioToReturn.PortfolioId }, portfolioToReturn);
        }*/
        [Authorize]
        [HttpPost("{portfolioId}/add-block")]
        public async Task<IActionResult> AddBlock([FromBody] ContentBlockForCreationDto contentBlock, Guid portfolioId)
        {
            var portfolioEntity = await _repository.Portfolio.GetPortfolioByIdAsync( portfolioId, trackChanges: false);
            if (portfolioEntity is null)
                return NotFound($"page with id {portfolioId} does not exist");

            var blockEntity = _mapper.Map<ContentBlock>(contentBlock);
            _repository.ContentBlock.CreateContentBlockAsync(blockEntity);

            await _repository.SaveAsync();

            var portfolioToReturn = _mapper.Map<PortfolioDto>(portfolioEntity);


            return CreatedAtRoute("portfoliosId", new { portfolioId = portfolioToReturn.PortfolioId }, portfolioToReturn);
        }
        [Authorize]
        [HttpPut("{portfolioId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePortfolioById(Guid portfolioId, [FromBody] PortfolioForUpdateDto portfolio)

        {
            var portfolioFromDb = await _repository.Portfolio.GetPortfolioBySlugNameAsync(portfolio.Slug, trackChanges: false);

            if (portfolioFromDb != null && portfolioFromDb.PortfolioId !=portfolioId)
            {
                portfolio.Slug += "-copy";
            }
            portfolio.AuthorId = User.GetUserId();

            var portfolioEntity = await _repository.Portfolio.GetPortfolioByIdAsync(portfolioId, trackChanges: true);
            if (portfolioEntity is null)
                return NotFound($"Portfolio with id {portfolioId} does not exist");



            _mapper.Map(portfolio, portfolioEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{portfolioId}")]
        public async Task<IActionResult> DeletePortfolio(Guid portfolioId)
        {


            var portfolioEntity = await _repository.Portfolio.GetPortfolioByIdAsync(portfolioId: portfolioId, trackChanges: false);
            if (portfolioEntity is null)
                return NotFound($"Portfolio with id {portfolioId} does not exist");


            _repository.Portfolio.DeletePortfolioAsync(portfolioEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}

