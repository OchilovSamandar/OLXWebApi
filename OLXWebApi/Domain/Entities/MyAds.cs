using OLXWebApi.Domain.Entities.Commans;

namespace OLXWebApi.Domain.Entities
{
    public class MyAds: Auditable
    {
        public long AnnouncementId { get; set; }
        public Announcement Announcement { get; set; }

    }
}