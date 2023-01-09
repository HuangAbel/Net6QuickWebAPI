namespace Models
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Select(TEntity entity);
        Task<IEnumerable<TEntity>> Insert(TEntity entity);
        Task<IEnumerable<TEntity>> Delete(TEntity entity);
        Task<IEnumerable<TEntity>> Update(TEntity entity);
    }
}
