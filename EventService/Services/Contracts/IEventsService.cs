using EventService.Models.Dto;

namespace EventService.Services.Contracts
{
    public interface IEventsService
    {
        Task<EventDto> CreateEvent(EventDto eventDto);
        Task<IEnumerable<EventDto>> GetEvents();
        Task<EventDto> GetEvent(int eventId);
    }
}
