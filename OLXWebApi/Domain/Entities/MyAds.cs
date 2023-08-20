using OLXWebApi.Domain.Entities.Commans;

namespace OLXWebApi.Domain.Entities
{
    public class MyAds: Auditable
    {
        public long AnnouncementId { get; set; }
        public Announcement Announcement { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

    }
}