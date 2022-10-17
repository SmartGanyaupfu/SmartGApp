using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartG.API.ActionFilters;
using SmartG.API.Extensions;
using SmartG.CloudinaryService;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.DTOs;
using SmartG.Shared.RequestFeatures;
using static System.Net.Mime.MediaTypeNames;
using Image = SmartG.Entities.Models.Image;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartG.API.Controllers.API.V1
{
    [Route("api/gallery")]
    public class GalleryController : Controller
    {
        
            private readonly IRepositoryManager _repository;
            private readonly IMapper _mapper;
            private readonly IImageUploader _imageService;

            public GalleryController(IRepositoryManager repository, IMapper mapper, IImageUploader imageService)
            {
                _repository = repository;
                _mapper = mapper;
                _imageService = imageService;
            }

            // GET: api/values
            [HttpGet]
        public async Task<IActionResult> GetGalleryList()
        {
            var galleryList = await _repository.Gallery.GetGalleryAsync( trackChanges: false);
            var galleryToReturn = _mapper.Map<IEnumerable<GalleryDto>>(galleryList);
            return Ok(galleryToReturn);
        }

        // GET api/values/5
        [HttpGet("{galleryId}", Name = "galleryRoute")]
        public async Task<IActionResult> GetGalleryById(int galleryId)
        {
            var gallery = await _repository.Gallery.GetGalleryByIdAsync(galleryId, trackChanges: false);
            if (gallery is null)
                return NotFound();
            var galleryToReturn = _mapper.Map<GalleryDto>(gallery);
            return Ok(galleryToReturn);
        }

        // POST api/values
        [HttpPost("new-gallery")]
        public async Task<IActionResult> AddGallery( [FromBody] GalleryForCreationDto galleryForCreation)
        {
           
            var galleryEntity = _mapper.Map<Gallery>(galleryForCreation);
            _repository.Gallery.CreateGalleryAsync(galleryEntity);
            await _repository.SaveAsync();
            var galleryToReturn = _mapper.Map<GalleryDto>(galleryEntity);

            return CreatedAtRoute("galleryRoute", new { galleryId = galleryToReturn.GalleryId }, galleryToReturn);
        }

        // POST api/values
        [HttpPost("{galleryId}/new-gallery")]
        public async Task<IActionResult> AddImagesToGallery(int galleryId, [FromBody] ICollection<GalleryImageDto> images )
        {

            /* var results = await _imageService.AddImageAsync(files);
             foreach (var result in results)
             {
                 if (result.Error != null)
                     return BadRequest(result.Error.Message);

                 var image = new ImageForCreationDto()
                 {
                     DateCreated = DateTime.Now,
                     DateUpdated = DateTime.Now,
                     Deleted = false,
                     PublicId = result.PublicId,
                     ImageUrl = result.SecureUrl.AbsoluteUri
                 };

                 galleryForCreation.Images?.Add(image);
            
             }*/
            foreach (var image in images)
            {
                image.GalleryId = galleryId;
                var imageEntity = await _repository.GalleryImage.GetGalleryImageByIdAsync(image.Id , trackChanges: true);
                if (imageEntity is null)
                    return NotFound($"Image with id {image.Id} does not exist.");

                _mapper.Map(image, imageEntity);
            }
            await _repository.SaveAsync();
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{galleryId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateGalleryById(int galleryId, [FromBody] GalleryForUpdateDto galleryForUpdate)

        {
            var galleryFromDb = await _repository.Gallery.GetGalleryForUpdateByIdAsync(galleryId, trackChanges: true);

            if (galleryFromDb is null)
                return NotFound($"Gallery with id {galleryId} does not exist");

            var galleryImages = await _repository.GalleryImage.GetGalleryImagesAsync(galleryId, trackChanges: false);
            foreach(var image in galleryImages)
            {
                // we want to delete all iamges linked to this gallery
                 _repository.GalleryImage.DeleteGalleryImageAsync(image);

            }

            _mapper.Map(galleryForUpdate, galleryFromDb);

            await _repository.SaveAsync();
            return NoContent();

        }

        // DELETE api/values/5
        [HttpDelete("{galleryId}")]
        public async Task<IActionResult> DeleteGallery(int galleryId)
        {


            var galleryEntity = await _repository.Gallery.GetGalleryByIdAsync(galleryId, trackChanges: false);
           /* if (galleryEntity is null)
                return NotFound($"Gallery with id {galleryId} does not exist");

            var galleryImages = await _repository.GalleryImage.GetGalleryImagesAsync(galleryId, trackChanges: false);
            foreach (var image in galleryImages)
            {
                _repository.GalleryImage.DeleteGalleryImageAsync(image);

            }*/


            _repository.Gallery.DeleteGalleryAsync(galleryEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}

