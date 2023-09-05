using OLXWebApi.Services.Dtos.RolePermission;

namespace OLXWebApi.Services.IService
{
    public interface IRolePermissionService
    {
        ValueTask<RolePermissionResultDto> CreateAsync(RolePermissionCreationDto dto);
        ValueTask<RolePermissionResultDto> ModifyAsync(RolePermissionCreationDto dto,long id);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<RolePermissionResultDto> RetrieveByIdAsync(long id);
        ValueTask<IEnumerable<RolePermissionResultDto>> RetrieveAllAsync();

    }
}
