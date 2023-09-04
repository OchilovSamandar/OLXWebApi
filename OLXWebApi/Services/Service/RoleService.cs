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
                throw new OlxWebApiException(409, "Role already exsist");
            var mappedDto = _mapper.Map<Role>(dto);
            await _repository.InsertAsync(mappedDto);
            await _repository.SaveChangesAsync();

            return _mapper.Map<RoleForResultDto>(mappedDto);         
        }

        public async ValueTask<bool> DeleteRoleAsync(long id)
        {
            var role = await _repository.SelectByIdAsync(id);
            if (role == null)
                throw new OlxWebApiException(404, "Role not found");

            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async ValueTask<IEnumerable<RoleForResultDto>> RetriveAllRoleAsync()
        {
            var roles = await _repository.SelectAll().ToListAsync();

            return _mapper.Map<IEnumerable<RoleForResultDto>>(roles);
        }

        public async ValueTask<Role> RetriveRoleByIdAsync(long id)
        {
           var exsistRole = await _repository.SelectByIdAsync(id);
            if (exsistRole == null)
                throw new OlxWebApiException(404, "Role is not found");

            return _mapper.Map<Role>(exsistRole);
        }

        public async ValueTask<RoleForResultDto> UpdateRoleAsync(RoleForUpdateDto dto, long id)
        {
           var exsistRole = await _repository.SelectByIdAsync(id);
            if (exsistRole == null)
                throw new OlxWebApiException(404, "Role is not found");

            var mappedDto = _mapper.Map(dto, exsistRole);
            mappedDto.UpdatedAt = DateTime.UtcNow;
            await _repository.SaveChangesAsync();
            var result = _mapper.Map<RoleForResultDto>(mappedDto);

            return result;
        }
    }
}
