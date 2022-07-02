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
    [Route("api/services")]

    public class ServicesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IImageUploader _imageService;

        public ServicesController(IRepositoryManager repository, IMapper mapper, IImageUploader imageService)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetServices([FromQuery] RequestParameters requestParameters)
        {

            var services = await _repository.Service.GetServicesAsync(requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(services.MetaData));
            var servicesToReturn = _mapper.Map<IEnumerable<ServiceDto>>(services);
            return Ok(servicesToReturn);
        }
        // GET api/values/5
        [HttpGet("{offeredServiceId}", Name = "offeredServicesId")]
        public async Task<IActionResult> GetServiceById(Guid offeredServiceId)
        {
            var service = await _repository.Service.GetServiceByIdAsync(offeredServiceId, trackChanges: false);
            if (service is null)
                return NotFound();
            var serviceToReturn = _mapper.Map<ServiceDto>(service);
            return Ok(serviceToReturn);
        }
        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> GetServiceBySlug(string slug)
        {
            var service = await _repository.Service.GetServiceBySlugAsync(slug, trackChanges: false);
            if (service is null)
                return NotFound();
            var pageToReturn = _mapper.Map<ServiceDto>(service);
            return Ok(pageToReturn);
        }
        [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateService([FromBody] ServiceForCreationDto service)
        {
            var serviceFromDb = await _repository.Service.GetServiceBySlugAsync(service.Slug, trackChanges: false);

            if (serviceFromDb != null)
            {
                service.Slug += "-copy";
            }

            service.AuthorId= User.GetUserId();

            var serviceEntity = _mapper.Map<OfferedService>(service);
            _repository.Service.CreateServiceAsync(serviceEntity);
            await _repository.SaveAsync();
            var serviceToReturn = _mapper.Map<ServiceDto>(serviceEntity);

            return CreatedAtRoute("offeredServicesId", new { offeredServiceId= serviceToReturn.OfferedServiceId }, serviceToReturn);
        }
        [Authorize]
        [HttpPost("{offeredServiceId}/add-image")]
        public async Task<IActionResult> AddImage(IFormFile file, Guid offeredServiceId)
        {
            var serviceEntity = await _repository.Service.GetServiceByIdAsync(offeredServiceId, trackChanges: true);
            if (serviceEntity is null)
                return NotFound($"Service with id {serviceEntity} does not exist");

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
            serviceEntity.Image = image;
          //  var serviceEntityToUpdate = _mapper.Map<serviceEntity>(i);
           // _repository.Image.CreateImageAsync(imageEntity);

            await _repository.SaveAsync();

            var serviceToReturn = _mapper.Map<ServiceDto>(serviceEntity);


            return CreatedAtRoute("offeredServicesId", new { offeredServiceId = serviceToReturn.OfferedServiceId }, serviceToReturn);
        }
        [Authorize]
        [HttpPost("{offeredServiceId}/add-block")]
        public async Task<IActionResult> AddBlock([FromBody] ContentBlockForCreationDto contentBlock, Guid offeredServiceId)
        {
            var serviceEntity = await _repository.Service.GetServiceByIdAsync(offeredServiceId, trackChanges: false);
            if (serviceEntity is null)
                return NotFound($"Service with id {offeredServiceId} does not exist");

            
            var blockEntity = _mapper.Map<ContentBlock>(contentBlock);
            _repository.ContentBlock.CreateContentBlockAsync(blockEntity);

            await _repository.SaveAsync();

            var serviceToReturn = _mapper.Map<ServiceDto>(serviceEntity);


            return CreatedAtRoute("offeredServicesId", new { offeredServiceId = serviceToReturn.OfferedServiceId }, serviceToReturn);
        }
        [Authorize]
        [HttpPut("{offeredServiceId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateServiceById(Guid offeredServiceId, [FromBody] ServiceForUpdateDto service)

        {
            var serviceFromDb = await _repository.Service.GetServiceBySlugAsync(service.Slug, trackChanges: false);

            if (serviceFromDb != null && serviceFromDb.OfferedServiceId !=offeredServiceId)
            {
               service.Slug += "-copy";
            }
            service.AuthorId = User.GetUserId();

            var serviceEntity = await _repository.Service.GetServiceByIdAsync(offeredServiceId, trackChanges: true);
            if (serviceEntity is null)
                return NotFound($"Service with id {offeredServiceId} does not exist");



            _mapper.Map(service, serviceEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{offeredServiceId}")]
        public async Task<IActionResult> DeleteService(Guid offeredServiceId)
        {


            var serviceEntity = await _repository.Service.GetServiceByIdAsync(serviceId: offeredServiceId, trackChanges: false);
            if (serviceEntity is null)
                return NotFound($"Service with id {offeredServiceId} does not exist");


            _repository.Service.DeleteServiceAsync(serviceEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}

