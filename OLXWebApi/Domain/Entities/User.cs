using OLXWebApi.Domain.Entities.Commans;
using OLXWebApi.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OLXWebApi.Domain.Entities
{
    public class User : Auditable
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public byte? Awatar { get; set; } 
        
        public List<MyAds> MyAdsList { get; set; } = new List<MyAds>();
        public List<Announcement> MyAnnouncementList { get; set; } = new List<Announcement>();
        public bool IsActive { get; set; } = true;
    }
}
