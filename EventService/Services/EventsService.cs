using AutoMapper;
using EventService.ExceptionHandling;
using EventService.Models.Dto;
using EventService.Models.Entities;
using EventService.Persistence;
using EventService.Services.Contracts;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var eventEntities = await _eventDbContext.Events.ToListAsync();

            return eventEntities;
        }

        public async Task<Event> GetEvent(int eventId)
        {
            return await GetEventOrThrowNotFound(eventId);
        }

        public async Task<EventDto> UpdateEvent(int eventId, EventDto eventDto)
        {
            var eventEntity = await GetEventOrThrowNotFound(eventId);

            _mapper.Map(eventDto, eventEntity);

            await _eventDbContext.SaveChangesAsync();

            return _mapper.Map<EventDto>(eventEntity);
        }

        private async Task<Event> GetEventOrThrowNotFound(int eventId)
        {
            var eventEntity = await _eventDbContext.Events.FirstOrDefaultAsync(e => e.Id == eventId);

            if (eventEntity == null)
                throw new NotFoundException("No events found.");

            return eventEntity;
        }
    }
}
