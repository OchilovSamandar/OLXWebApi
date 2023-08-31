using OLXWebApi.Domain.Entities.Commans;
using System.Diagnostics.CodeAnalysis;

namespace OLXWebApi.Domain.Entities
{
    public class Permission : Auditable
    {
        [NotNull]
        public string Name { get; set; }
    }
}
