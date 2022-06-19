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
    [Route("api/content-blocks")]
    public class BlocksController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IImageUploader _imageService;

        public BlocksController(IRepositoryManager repository, IMapper mapper, IImageUploader imageService)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlock([FromBody] ContentBlockForCreationDto contentBlock)
        {

            
            var blockEntity = _mapper.Map<ContentBlock>(contentBlock);
            _repository.ContentBlock.CreateContentBlockAsync(blockEntity);
            await _repository.SaveAsync();
            var blockToReturn = _mapper.Map<ContentBlockDto>(blockEntity);
            return CreatedAtRoute("blocksId", new { contentBlockId = blockToReturn.ContentBlockId }, blockToReturn);
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetBlocks([FromQuery] RequestParameters requestParameters)
        {

            var blocksFromDb = await _repository.ContentBlock.GetContentBlocksAsync(requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(blocksFromDb.MetaData));
            var blocksToReturn = _mapper.Map<IEnumerable<ContentBlockDto>>(blocksFromDb);
            return Ok(blocksToReturn);
        }

        // GET api/values/5
        [HttpGet("{contentBlockId}", Name = "blocksId")]
        public async Task<IActionResult> GetBlockById(Guid contentBlockId)
        {
            var blockFromDb = await _repository.ContentBlock.GetContentBlockByIdAsync(contentBlockId, trackChanges: false);
            if (blockFromDb is null)
                return NotFound($"Content Block with id {contentBlockId} is not found.");
            var blockToReturn = _mapper.Map<ContentBlockDto>(blockFromDb);
            return Ok(blockToReturn);
        }

        [HttpPut("{contentBlockId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateBlockById(Guid contentBlockId, [FromBody] ContentBlockForUpdateDto contentBlock)
        {

            var blockEntity = await _repository.ContentBlock.GetContentBlockByIdAsync(contentBlockId, trackChanges: true);
            if (blockEntity is null)
                return NotFound($"Content Block with id {contentBlockId} does not exist");



            _mapper.Map(contentBlock, blockEntity);

            await _repository.SaveAsync();
            return NoContent();
        }


        [HttpDelete("{contentBlockId}")]
        public async Task<IActionResult> DeleteImage(Guid contentBlockId)
        {


            var blockEntity = await _repository.ContentBlock.GetContentBlockByIdAsync(contentBlockId, trackChanges: false);
            if (blockEntity is null)
                return NotFound($"Image with id {contentBlockId} does not exist.");

            

            _repository.ContentBlock.DeleteContentBlockAsync(blockEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}

