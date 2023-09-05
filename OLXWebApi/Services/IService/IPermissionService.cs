using OLXWebApi.Services.Dtos.Permission;

namespace OLXWebApi.Services.IService
{
    public interface IPermissionService
    {
        ValueTask<PermissionResultDto> CreatePermission(PermissionCreationDto permissonCreationDto);
        ValueTask<PermissionResultDto> UpdatePermission(PermissionCreationDto permissonCreationDto,long id);
        ValueTask<bool> DeletePermission(long id);
        ValueTask<PermissionResultDto> GetPermission(long id);
        ValueTask<IEnumerable<PermissionResultDto>> GetAllPermissions();
    }
}
