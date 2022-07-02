using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartG.API.ActionFilters;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.DTOs;
using SmartG.Shared.RequestFeatures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartG.API.Controllers.API.V1
{
    
    [Route("api/categories")]

    public class CategoryController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CategoryController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] CategoryParameters categoryParameters)
        {

            var categories = await _repository.Category.GetAllCategoriesAsync(categoryParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(categories.MetaData));
            var categoriesToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(categoriesToReturn);
        }

        // GET api/values/5
        [HttpGet("{categoryId}", Name = "categoriesId")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var category = await _repository.Category.GetCategoryByIdAsync(categoryId, trackChanges: false);
            if (category is null)
                return NotFound();
            var categoryToReturn = _mapper.Map<CategoryDto>(category);
            return Ok(categoryToReturn);
        }


        [Authorize]

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto category)
        {
            var categoryFromDb = await _repository.Category.GetCategoryBySlugAsync(category.Slug, trackChanges: false);

            if (categoryFromDb != null)
            {
                category.Slug += "-copy";
            }


            var categoryEntity = _mapper.Map<Category>(category);
            _repository.Category.CreateCategoryAsync(categoryEntity);
            await _repository.SaveAsync();
            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            //var votesToReturn = await _serviceManager.QualificationService.CreateQualificationForStudyOptionAsync(studyOptionId, qualification, trackChanges: false);
            return CreatedAtRoute("categoriesId", new { categoryId = categoryToReturn.CategoryId }, categoryToReturn);
        }


        [Authorize]
        [HttpPut("{categoryId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCategoryById(int categoryId, [FromBody] CategoryForUpdateDto category)
        {
            var categoryFromDb = await _repository.Category.GetCategoryBySlugAsync(category.Slug, trackChanges: false);

            if (categoryFromDb != null && categoryFromDb.CategoryId !=categoryId)
            {
                category.Slug += "-copy";
            }

            var categoryEntity = await _repository.Category.GetCategoryByIdAsync(categoryId, trackChanges: true);
            if (categoryEntity is null)
                return NotFound($"Category with id {categoryId} does not exist");



            _mapper.Map(category, categoryEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {


            var categoryEntity = await _repository.Category.GetCategoryByIdAsync(categoryId: categoryId, trackChanges: false);
            if (categoryEntity is null)
                return NotFound($"Category with id {categoryId} does not exist");




            _repository.Category.DeleteCategoryAsync(categoryEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}

