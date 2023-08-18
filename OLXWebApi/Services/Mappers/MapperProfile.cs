
using AutoMapper;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;

namespace OLXWebApi.Services.Mappers
{
    public class MapperProfile : Profile 
    {
        public MapperProfile()
        {
            CreateMap<User, UserForCreationDto>().ReverseMap();
            CreateMap<UserForResultDto, User>().ReverseMap();

            CreateMap<Announcement, AnnouncementCreationDto>().ReverseMap();

            CreateMap<Category,CategoryForCreationDto>().ReverseMap();

        }
    }
}
