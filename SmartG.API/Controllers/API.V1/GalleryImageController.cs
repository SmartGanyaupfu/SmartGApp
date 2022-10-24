using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartG.Contracts;
using SmartG.Entities.Models;
using SmartG.Shared.DTOs;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartG.API.Controllers.API.V1
{
    [Route("api/gallery-image")]
    public class GalleryImageController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IImageUploader _imageService;

        public GalleryImageController(IRepositoryManager repository, IMapper mapper, IImageUploader imageService)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var galleryImageEntity = await _repository.GalleryImage.GetGalleryImageByIdAsync(id, trackChanges: false);
            if (galleryImageEntity is null)
                return NotFound($"Gallery Image with id {id} does not exist");

            
                _repository.GalleryImage.DeleteGalleryImageAsync(galleryImageEntity);


            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut ("{id}")]
        public async Task <IActionResult> UpdateImage(int id, [FromBody] GalleryImageForUpdateDto image)
        {

            var imageEntity = await _repository.GalleryImage.GetGalleryImageByIdAsync(id, trackChanges: true);
            if (imageEntity is null)
                return NotFound($"Image with id {id} does not exist.");

            _mapper.Map(image, imageEntity);
        
        await _repository.SaveAsync();
            return NoContent();
    }
    }
}

