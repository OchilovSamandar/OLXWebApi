using OLXWebApi.Domain.Entities.Commans;

namespace OLXWebApi.Domain.Entities
{
    public class Announcement : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public byte[] Awatars { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public long  UserId { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
    }
}