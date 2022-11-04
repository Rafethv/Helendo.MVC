using Entity.Entity;
using System.Linq.Expressions;

namespace Core.EFRepository.EFBase;

public interface IEFRepositoryBase<TEntity>
    where TEntity : class, IEntity, new()
{
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes);
    Task<List<TEntity>> PaginationAsync(Expression<Func<TEntity, bool>>? expression = null, int? page = 0, int? pageSize = int.MaxValue, params string[] includes);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
