using OLXWebApi.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OLXWebApi.Services.Dtos.RolePermission
{
    public class RolePermissionCreationDto
    {
        [Required(ErrorMessage = "RoleId is required")]
        public long  RoleId { get; set; }
        
        [Required(ErrorMessage = "PermissionId is required")]
        public long  PermissionId { get; set; }
    }
}
