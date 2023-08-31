using System.ComponentModel.DataAnnotations;

namespace OLXWebApi.Services.Dtos.Role
{
    public class RoleForCreationDto
    {
        [Required]
        public string Name { get; set; }
    }
}
