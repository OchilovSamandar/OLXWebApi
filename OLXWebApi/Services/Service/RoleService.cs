using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos.Role;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Services.Service
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Role> _repository;

        public ValueTask<bool> AssignRoleForUserAsync(long userId, long roleId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> CheckRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<RoleForResultDto> CreateRoleAsync(RoleForCreationDto dto)
        {
            await _repository.SelectAll().FirstOrDefaultAsync(r => r.Name.Equals(dto.Name));
            return;
        }

        public ValueTask<bool> DeleteRoleAsync(long id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<RoleForResultDto>> RetriveAllRoleAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Role> RetriveRoleByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<RoleForResultDto> UpdateRoleAsync(RoleForUpdateDto dto, long id)
        {
            throw new NotImplementedException();
        }
    }
}
