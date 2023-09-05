using OLXWebApi.Domain.Entities.Commans;

namespace OLXWebApi.Domain.Entities
{
    public class RolePermission : Auditable
    {
        public long RoleId { get; set; }
        public Role Role { get; set; }

        public long PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
