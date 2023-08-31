using OLXWebApi.Domain.Entities;
using OLXWebApi.Services.Dtos;
using OLXWebApi.Services.Dtos.Role;

namespace OLXWebApi.Services.IService
{
    public interface IRoleService
    {
        ValueTask<RoleForResultDto> CreateRoleAsync(RoleForCreationDto dto);
        ValueTask<RoleForResultDto> UpdateRoleAsync(RoleForUpdateDto dto, long id);
        ValueTask<bool> DeleteRoleAsync(long id);
        ValueTask<Role> RetriveRoleByIdAsync(long id);
        ValueTask<IEnumerable<RoleForResultDto>> RetriveAllRoleAsync();
        ValueTask<bool> AssignRoleForUserAsync(long userId, long  roleId);
        ValueTask<bool> CheckRole(string roleName);
    }
}
