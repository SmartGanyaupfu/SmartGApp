using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartG.API.ActionFilters;
using SmartG.CloudinaryService;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.DTOs;
using SmartG.Shared.RequestFeatures;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartG.API.Controllers.API.V1
{
    [Route("api/pages")]
    
    public class PageController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IImageUploader _imageService;

        public PageController(IRepositoryManager repository, IMapper mapper, IImageUploader imageService)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetPages([FromQuery] PageParameters pageParameters)
        {
           
            var pages = await _repository.Page.GetAllPagesAsync(pageParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pages.MetaData));
            var pagesToReturn = _mapper.Map<IEnumerable<PageDto>>(pages);
            return Ok(pagesToReturn);
        }

        // GET api/values/5
        [HttpGet("{pageId}", Name = "pagesId")]
        public async Task<IActionResult> GetPageById(int pageId)
        {
            var page = await _repository.Page.GetPageByIdAsync(pageId, trackChanges: false);
            if (page is null)
                return NotFound();
            var pageToReturn = _mapper.Map<PageDto>(page);
            return Ok(pageToReturn);
        }

       

        
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePage([FromBody] PageForCreationDto page)
        {
            var pagesFromDb = await _repository.Page.GetPageBySlugNameAsync(page.Slug, trackChanges: false);

            if (pagesFromDb != null)
            {
                page.Slug += "copy";
            }


            var pageEntity = _mapper.Map<Page>(page);
            _repository.Page.CreatePageAsync(pageEntity);
            await _repository.SaveAsync();
            var pageToReturn = _mapper.Map<PageDto>(pageEntity);

            //var votesToReturn = await _serviceManager.QualificationService.CreateQualificationForStudyOptionAsync(studyOptionId, qualification, trackChanges: false);
            return CreatedAtRoute("pagesId", new { pageId = pageToReturn.PageId }, pageToReturn);
        }
        [HttpPost("add-image")]
        public async Task<IActionResult> AddImage(IFormFile file)
        {
            var result = await _imageService.AddImageAsync(file);
            if (result.Error != null)
                return BadRequest(result.Error.Message);

            return Ok(result);
        }

      
        [HttpPut("{pageId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePageById(int pageId, [FromBody] PageForUpdateDto page)
        {

            var pageEntity = await _repository.Page.GetPageByIdAsync(pageId, trackChanges: true);
            if (pageEntity is null)
                return NotFound($"page with id {pageId} does not exist");



            _mapper.Map(page, pageEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        
        [HttpDelete("{pageId}")]
        public async Task<IActionResult> DeleteValue(int pageId)
        {


            var pageEntity = await _repository.Page.GetPageByIdAsync(pageId: pageId, trackChanges: false);
            if (pageEntity is null)
                return NotFound($"page with id {pageId} does not exist");




            _repository.Page.DeletePageAsync(pageEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}

