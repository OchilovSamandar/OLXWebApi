using OLXWebApi.Domain.Entities.Commans;

namespace OLXWebApi.Domain.Entities
{
    public class Role : Auditable
    {
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
