using System.ComponentModel.DataAnnotations;

namespace OLXWebApi.Services.Dtos
{
    public interface CategoryForCreationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
