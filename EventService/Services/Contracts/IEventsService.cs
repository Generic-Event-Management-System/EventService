using EventService.Models.Dto;
using EventService.Models.Entities;

namespace EventService.Services.Contracts
{
    public interface IEventsService
    {
        Task<Event> CreateEvent(EventDto eventDto);
        Task<IEnumerable<Event>> GetEvents();
        Task<Event> GetEvent(int eventId);
        Task<Event> UpdateEvent(int eventId, EventDto eventDto);
        Task DeleteEvent(int eventId);
    }
}
