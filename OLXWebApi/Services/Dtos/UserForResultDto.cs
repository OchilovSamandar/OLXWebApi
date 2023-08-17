using OLXWebApi.Domain.Entities.Commans;
using OLXWebApi.Domain.Enums;

namespace OLXWebApi.Services.Dtos
{
    public class UserForResultDto : Auditable
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
