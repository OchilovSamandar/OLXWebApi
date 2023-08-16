using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities.Commans;

namespace OLXWebApi.Data.Repositories
{
    public class Repository<TEntity> :  IRepository<TEntity> where TEntity : Auditable
    {
        
    }
}
