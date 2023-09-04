
using AutoMapper;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Dtos.Role;

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

            CreateMap<MyAds,MyAdsCreationDto>().ReverseMap();

            CreateMap<Role,RoleForCreationDto>().ReverseMap();
            CreateMap<RoleForResultDto, Role>().ReverseMap();

        }
    }
}
