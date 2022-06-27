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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartG.API.Controllers.API.V1
{
    [Route("api/widgets")]

    public class WidgetsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public WidgetsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetWidgets()
        {

            var widgets = await _repository.Widget.GetWidgetsAsync( trackChanges: false);
            var widgetsToReturn = _mapper.Map<WidgetDto>(widgets);
            return Ok(widgetsToReturn);
        }

        // GET api/values/5
        [HttpGet("{widgetId}", Name = "widgetsId")]
        public async Task<IActionResult> GetWidgetById(int widgetId)
        {
            var widget = await _repository.Widget.GetWidgetByIdAsync(widgetId, trackChanges: false);
            if (widget is null)
                return NotFound();
            var widgetToReturn = _mapper.Map<WidgetDto>(widget);
            return Ok(widgetToReturn);
        }




        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateWidget([FromBody] WidgetForCreationDto widget)
        {
           


            var widgetEntity = _mapper.Map<Widget>(widget);
            _repository.Widget.CreateWidgetAsync(widgetEntity);
            await _repository.SaveAsync();
            var widgetToReturn = _mapper.Map<WidgetDto>(widgetEntity);
            return CreatedAtRoute("widgetsId", new { widgetId = widgetToReturn.WidgetId }, widgetToReturn);
        }



        [HttpPut("{widgetId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateWidgetById(int widgetId, [FromBody] WidgetForUpdateDto widget)
        {
           

            var widgetEntity = await _repository.Widget.GetWidgetByIdAsync(widgetId, trackChanges: true);
            if (widgetEntity is null)
                return NotFound($"Widget with id {widgetId} does not exist");



            _mapper.Map(widget, widgetEntity);

            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{widgetId}")]
        public async Task<IActionResult> DeleteWidget(int widgetId)
        {


            var widgetEntity = await _repository.Widget.GetWidgetByIdAsync(widgetId, trackChanges: true);
            if (widgetEntity is null)
                return NotFound($"Widget with id {widgetId} does not exist");




            _repository.Widget.DeleteWidgetAsync(widgetEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}

