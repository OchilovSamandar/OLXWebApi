using OLXWebApi.Domain.Entities.Commans;

namespace OLXWebApi.Domain.Entities
{
    public class Category: Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}