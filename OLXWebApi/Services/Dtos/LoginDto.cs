using OLXWebApi.Services.Commons.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OLXWebApi.Services.Dtos
{
    public class LoginDto
    {
        [Email]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StrongPassword]
        public string Password { get; set; }
    }
}
