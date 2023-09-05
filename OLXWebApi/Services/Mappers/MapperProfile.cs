
using AutoMapper;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Dtos.Permission;
using OLXWebApi.Services.Dtos.Role;
using OLXWebApi.Services.Dtos.RolePermission;

namespace OLXWebApi.Services.Mappers
{
    public class MapperProfile : Profile 
    {
        public MapperProfile()
        {
            //user
            CreateMap<User, UserForCreationDto>().ReverseMap();
            CreateMap<UserForResultDto, User>().ReverseMap();
            //announcement
            CreateMap<Announcement, AnnouncementCreationDto>().ReverseMap();
            //category
            CreateMap<Category,CategoryForCreationDto>().ReverseMap();
            //myads
            CreateMap<MyAds,MyAdsCreationDto>().ReverseMap();
            //role
            CreateMap<Role,RoleForCreationDto>().ReverseMap();
            CreateMap<RoleForResultDto, Role>().ReverseMap();
            //permision
            CreateMap<Permission,PermissionCreationDto>().ReverseMap();
            CreateMap<PermissionResultDto,Permission>().ReverseMap();
            //rolepermission
            CreateMap<RolePermission,RolePermissionCreationDto>().ReverseMap();
            CreateMap<RolePermissionResultDto,RolePermission>().ReverseMap();
        }
    }
}
