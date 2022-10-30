using Entity.Entity;

namespace Business.Base
{
    public interface IBaseService<TEntity>
        where TEntity : class, IEntity, new()
    {
        Task<TEntity> GetAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(int id, TEntity entity);
        Task DeleteAsync(int id);
    }
}
