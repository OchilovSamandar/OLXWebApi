namespace OLXWebApi.Services.Dtos
{
    public class AnnouncementCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public byte[] Awatars { get; set; }
        public long CategoryId { get; set; }
        public long UserId { get; set; }
    }
}
