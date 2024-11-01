using AutoMapper;
using EventService.Models.Dto;
using EventService.Models.Entities;

namespace EventService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
        }
    }
}
