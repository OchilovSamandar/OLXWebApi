using Microsoft.EntityFrameworkCore;
using OLXWebApi.Data.DbContexts;
using OLXWebApi.Data.IRepositories;
using OLXWebApi.Domain.Entities.Commans;
using System.Linq;

namespace OLXWebApi.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        private readonly OlxDbContext _olxDbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(OlxDbContext olxDbContext)
        {
            _olxDbContext = olxDbContext;
            _dbSet = _olxDbContext.Set<TEntity>();
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var entity = await this._dbSet.FindAsync(id);
            this._dbSet.Remove(entity);

            return await this._olxDbContext.SaveChangesAsync()>0;
        }

        public async ValueTask<TEntity> InsertAsync(TEntity entity)
        {
           var entry = await this._dbSet.AddAsync(entity);
           await this._olxDbContext.SaveChangesAsync();

           return entry.Entity;
        }

        public async ValueTask<bool> SaveChangesAsync()
        {
            return await this._olxDbContext.SaveChangesAsync() > 0;
        }

        public IQueryable<TEntity> SelectAll()
        {
            return this._dbSet;
        }

        public async ValueTask<TEntity> SelectByIdAsync(long id)
        {
            return await this._dbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async ValueTask<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = this._dbSet.Update(entity);
            await this._olxDbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
