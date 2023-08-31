using System.ComponentModel.DataAnnotations;

namespace OLXWebApi.Domain.Entities.Commans
{
    public class Auditable
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
