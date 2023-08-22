using Microsoft.AspNetCore.Identity;
using OLXWebApi.Domain.Enums;

namespace OLXWebApi.Domain.Entities
{
    public class Role : IdentityRole
    {
        public int Id { get; set; }
        public UserRole Name { get; set; }

    }
}
