using EventService.Models.Dto;
using EventService.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventService.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService _eventsService;

        public EventsController(IEventsService eventsService) 
        {
            _eventsService = eventsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventDto eventDto)
        {
            return Ok( await _eventsService.CreateEvent(eventDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetEventList()
        {
            return Ok( await _eventsService.GetEvents());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            return Ok( await _eventsService.GetEvent(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, EventDto eventDto)
        {
            return Ok(await _eventsService.UpdateEvent(id, eventDto));
        }
    }
}
