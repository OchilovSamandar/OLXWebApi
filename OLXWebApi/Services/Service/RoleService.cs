using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos.Role;
using OLXWebApi.Services.Exceptions;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Services.Service
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Role> _repository;

        public RoleService(IMapper mapper, IRepository<Role> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

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
           var role =  await _repository.SelectAll().FirstOrDefaultAsync(r => r.Name.Equals(dto.Name));
            if (role != null)
                throw new OlxWebApiException(404, "Role already exsist");
            var mappedDto = _mapper.Map<Role>(dto);
            await _repository.InsertAsync(mappedDto);
            await _repository.SaveChangesAsync();

            return _mapper.Map<RoleForResultDto>(mappedDto);         
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
