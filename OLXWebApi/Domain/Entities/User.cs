using Microsoft.AspNetCore.Identity;
using OLXWebApi.Domain.Entities.Commans;
using OLXWebApi.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OLXWebApi.Domain.Entities
{
    public class User : Auditable 
    {
        public long  Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public byte? Awatar { get; set; }
        public List<MyAds> MyAdsList { get; set; } 
        public List<Announcement> MyAnnouncementList { get; set; } 
        public bool IsActive { get; set; } = true;
    }
}
