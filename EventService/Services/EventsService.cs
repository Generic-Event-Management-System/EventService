using AutoMapper;
using EventService.Models.Dto;
using EventService.Models.Entities;
using EventService.Persistence;
using EventService.Services.Contracts;

namespace EventService.Services
{
    public class EventsService : IEventsService
    {
        private readonly EventDbContext _eventDbContext;
        private readonly IMapper _mapper;

        public EventsService(EventDbContext eventDbContext, IMapper mapper) 
        {
            _eventDbContext = eventDbContext;
            _mapper = mapper;
        }

        public async Task<EventDto> CreateEvent(EventDto eventDto)
        {
            var eventEntity = _mapper.Map<Event>(eventDto);

            await _eventDbContext.Events.AddAsync(eventEntity);

            await _eventDbContext.SaveChangesAsync();

            return eventDto;
        }
    }
}
