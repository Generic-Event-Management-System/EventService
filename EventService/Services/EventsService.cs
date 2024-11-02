using AutoMapper;
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

        public async Task<IEnumerable<EventDto>> GetEvents()
        {
            var eventEntities = await _eventDbContext.Events.ToListAsync();

            return _mapper.Map<IEnumerable<EventDto>>(eventEntities);
        }

        public async Task<EventDto> GetEvent(int eventId)
        {
            var eventEntity = await _eventDbContext.Events.FirstOrDefaultAsync(e => e.Id == eventId);

            return _mapper.Map<EventDto>(eventEntity);
        }
    }
}
