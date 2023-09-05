using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos.RolePermission;
using OLXWebApi.Services.Exceptions;
using OLXWebApi.Services.IService;

namespace OLXWebApi.Services.Service
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRepository<RolePermission> repository;
        private readonly IMapper mapper;
        private readonly IRepository<Role> roleRepository;
        private readonly IRepository<Permission> permissionRepository;

        public RolePermissionService(IRepository<RolePermission> repository, IMapper mapper,
            IRepository<Role> roleRepository, IRepository<Permission> permissionRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.roleRepository = roleRepository;
            this.permissionRepository = permissionRepository;
        }

        public async ValueTask<RolePermissionResultDto> CreateAsync(RolePermissionCreationDto dto)
        {
            var role = await roleRepository.SelectByIdAsync(dto.RoleId);
            var permission = await permissionRepository.SelectByIdAsync(dto.PermissionId);
            if (role == null || permission == null)
                throw new OlxWebApiException(404, "Role or permission is not found");

             var rolePermission = await repository.SelectAll().FirstOrDefaultAsync(rp => rp.RoleId == dto.RoleId && rp.PermissionId==dto.PermissionId);
            if (rolePermission != null)
                throw new OlxWebApiException(409, "RolePermission is already available");

            var mappedRolePermission =this.mapper.Map<RolePermission>(dto);
            mappedRolePermission.CreatedAt = DateTime.UtcNow;
            var result = await repository.InsertAsync(mappedRolePermission);

            return mapper.Map<RolePermissionResultDto>(result);
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var rolePermission = await repository.SelectByIdAsync(id);
            if (rolePermission == null)
                throw new OlxWebApiException(404, "Not found");

            var result =  await repository.DeleteAsync(id);

            return result;
        }

        public async ValueTask<RolePermissionResultDto> ModifyAsync(RolePermissionCreationDto dto, long id)
        {
            var rolePermission = await repository.SelectByIdAsync(id);
            if (rolePermission == null)
                throw new OlxWebApiException(404, "Not found");
            var result = mapper.Map(dto, rolePermission);
            result.UpdatedAt= DateTime.UtcNow;
            await repository.SaveChangesAsync();

            return mapper.Map<RolePermissionResultDto>(result);
        }

        public async ValueTask<IEnumerable<RolePermissionResultDto>> RetrieveAllAsync()
        {
            var rp = await repository.SelectAll().ToListAsync();
            return mapper.Map<List<RolePermissionResultDto>>(rp);
        }

        public async ValueTask<RolePermissionResultDto> RetrieveByIdAsync(long id)
        {
            var rp = await repository.SelectByIdAsync(id);
            if (rp == null)
                throw new OlxWebApiException(404, "Not found");

            var result = mapper.Map<RolePermissionResultDto>(rp);

            return result;
        }
    }
}
