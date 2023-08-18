using System.ComponentModel.DataAnnotations;

namespace OLXWebApi.Services.Dtos
{
    public class CategoryForCreationDto
    {
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}
