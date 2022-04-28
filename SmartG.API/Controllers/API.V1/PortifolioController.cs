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
    [Route("api/portifolios")]

    public class PortifolioController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PortifolioController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetPortifolios([FromQuery] RequestParameters requestParameters)
        {

            var portifolios = await _repository.Portifolio.GetAllPortifoliosAsync(requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(portifolios.MetaData));
            var portifoliosToReturn = _mapper.Map<IEnumerable<PortifolioDto>>(portifolios);
            return Ok(portifoliosToReturn);
        }
        // GET api/values/5
        [HttpGet("{portifolioId}", Name = "portifoliosId")]
        public async Task<IActionResult> GetPortifolioById(Guid portifolioId)
        {
            var portifolio = await _repository.Portifolio.GetPortifolioByIdAsync(portifolioId, trackChanges: false);
            if (portifolio is null)
                return NotFound();
            var portifolioToReturn = _mapper.Map<PortifolioDto>(portifolio);
            return Ok(portifolioToReturn);
        }


        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePortifolio([FromBody] PortifolioForCreationDto portifolio)
        {
            var portifolioFromDb = await _repository.Portifolio.GetPortifolioBySlugNameAsync(portifolio.Slug, trackChanges: false);

            if (portifolioFromDb != null)
            {
                portifolio.Slug += "-copy";
            }


            var portifolioEntity = _mapper.Map<Portifolio>(portifolio);
            _repository.Portifolio.CreatePortifolioAsync(portifolioEntity);
            await _repository.SaveAsync();
            var portifolioToReturn = _mapper.Map<PortifolioDto>(portifolioEntity);

            return CreatedAtRoute("portifoliosId", new { portifolioId = portifolioToReturn.PortifolioId }, portifolioToReturn);
        }



        [HttpPut("{portifolioId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePortifolioById(Guid portifolioId, [FromBody] PortifolioForUpdateDto portifolio)

        {

            var portifolioEntity = await _repository.Portifolio.GetPortifolioByIdAsync(portifolioId, trackChanges: true);
            if (portifolioEntity is null)
                return NotFound($"Portifolio with id {portifolioId} does not exist");



            _mapper.Map(portifolio, portifolioEntity);

            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{portifolioId}")]
        public async Task<IActionResult> DeletePortifolio(Guid portifolioId)
        {


            var portifolioEntity = await _repository.Portifolio.GetPortifolioByIdAsync(portifolioId: portifolioId, trackChanges: false);
            if (portifolioEntity is null)
                return NotFound($"Portifolio with id {portifolioId} does not exist");


            _repository.Portifolio.DeletePortifolioAsync(portifolioEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}

