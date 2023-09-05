using OLXWebApi.Services.Dtos.Permission;
using OLXWebApi.Services.Dtos.Role;

namespace OLXWebApi.Services.Dtos.RolePermission
{
    public class RolePermissionResultDto
    {
        public long  Id { get; set; }
        public long  RoleId { get; set; }
        public RoleForResultDto Role { get; set; }
        public long  PermissionId { get; set; }
        public PermissionResultDto Permission { get; set; }
    }
}
