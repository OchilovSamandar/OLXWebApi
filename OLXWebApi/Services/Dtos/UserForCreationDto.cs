using OLXWebApi.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OLXWebApi.Services.Dtos
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "Firstname is requaired not empty")]
        //[MaxLength(50,ErrorMessage = "the number of characters should not exceed 50")]
        //[MinLength(3,ErrorMessage = "the number of characters should not be less than 3")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is requaired not empty")]
        //[MaxLength(50, ErrorMessage = "the number of characters should not exceed 50")]
        //[MinLength(3, ErrorMessage = "the number of characters should not be less than 3")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Email is requaired not empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is requaired not empty")]
        public string Password { get; set; }
        

    }
}
