using EventService.Models.Dto;
using EventService.Models.Entities;

namespace EventService.Services.Contracts
{
    public interface IEventsService
    {
        Task<EventDto> CreateEvent(EventDto eventDto);
        Task<IEnumerable<Event>> GetEvents();
        Task<Event> GetEvent(int eventId);
        Task<EventDto> UpdateEvent(int eventId, EventDto eventDto);
    }
}
