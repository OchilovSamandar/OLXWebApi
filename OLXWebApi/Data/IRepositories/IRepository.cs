namespace OLXWebApi.Data.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> InsertAsync(TEntity entity);
        ValueTask<TEntity> UpdateAsync(TEntity entity);
        ValueTask<bool> DeleteAsync(long id);
        IQueryable<TEntity> SelectAllAsync();
        ValueTask<TEntity> SelectByIdAsync(long id);
        ValueTask<bool> SaveChangesAsync(); 
    }
}
