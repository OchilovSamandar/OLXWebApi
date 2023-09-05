using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos.Permission;
using OLXWebApi.Services.Exceptions;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Services.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepository<Permission> _repository;
        private readonly IMapper _mapper;

        public PermissionService(IRepository<Permission> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async ValueTask<PermissionResultDto> CreatePermission(PermissionCreationDto permissonCreationDto)
        {
            var exsistPermission = await _repository.SelectAll()
                .FirstOrDefaultAsync(p => p.Name.Equals(permissonCreationDto.Name));

            if (exsistPermission is not null)
                throw new OlxWebApiException(409, "Permission name is already available");

            var mappedPermission =  _mapper.Map<Permission>(permissonCreationDto);
            var result = await _repository.InsertAsync(mappedPermission);
            await _repository.SaveChangesAsync();

            return _mapper.Map<PermissionResultDto>(result);
        }

        public async ValueTask<bool> DeletePermission(long id)
        {
            var permission = await _repository.SelectByIdAsync(id);
            if (permission == null)
                throw new OlxWebApiException(404, "Permission not found");

            await _repository.DeleteAsync(id);

            return true;
        }

        public async ValueTask<IEnumerable<PermissionResultDto>> GetAllPermissions()
        {
           var permissions = await _repository.SelectAll().ToListAsync();
            return _mapper.Map<List<PermissionResultDto>>(permissions);
        }

        public async ValueTask<PermissionResultDto> GetPermission(long id)
        {
            var permission = await _repository.SelectByIdAsync(id);
            if (permission == null)
                throw new OlxWebApiException(404, "Permission is not available");

            return _mapper.Map<PermissionResultDto>(permission);
        }

        public async ValueTask<PermissionResultDto> UpdatePermission(PermissionCreationDto permissonCreationDto, long id)
        {
            var permission = await _repository.SelectByIdAsync(id);
            if (permission == null)
                throw new OlxWebApiException(404, "Permission is not found");

            var result =  _mapper.Map(permissonCreationDto, permission);
            result.UpdatedAt = DateTime.UtcNow;
            await _repository.SaveChangesAsync();

            return _mapper.Map<PermissionResultDto>(result);
        }
    }
}
