using System.ComponentModel.DataAnnotations;

namespace OLXWebApi.Services.Dtos.Role
{
    public class RoleForUpdateDto
    {
        [Required]
        public long RoleId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
