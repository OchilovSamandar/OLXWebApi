using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OLXWebApi.Services.Dtos.Permission
{
    public class PermissionCreationDto
    {
        [NotNull, MinLength(3), MaxLength(50)]
        public string Name { get; set; }
    }
}
