using Core.EFRepository.EFBase;
using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.EFRepository;

public class EFRepositoryBase<TEntity, TContext> : IEFRepositoryBase<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext
{
    private readonly TContext _context;

    public EFRepositoryBase(TContext context)
    {
        _context = context;
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes)
    {
        var query = expression == null ?
            _context.Set<TEntity>().AsNoTracking() :
            _context.Set<TEntity>().Where(expression).AsNoTracking();

        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        var data = await query.FirstOrDefaultAsync();

#pragma warning disable CS8603 // Possible null reference return.
        return data;
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes)
    {
        var query = expression == null ?
            _context.Set<TEntity>().AsNoTracking() :
            _context.Set<TEntity>().Where(expression).AsNoTracking();


        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        var data = await query.ToListAsync();

        return data;
    }

    public async Task CreateAsync(TEntity entity)
    {
        var entry = _context.Entry(entity);
        entry.State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        var entry = _context.Entry(entity);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        var entry = _context.Entry(entity);
        entry.State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> PaginationAsync<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, Expression<Func<TEntity, bool>>? expression = null, int? page = 1, int? pageSize = 6, params string[] includes)
    {
        var query = expression == null ?
            _context.Set<TEntity>().Skip((int)((page - 1) * pageSize)).Take((int)pageSize).AsNoTracking() :
            _context.Set<TEntity>().Where(expression).OrderByDescending(orderBy).Skip((int)((page - 1) * pageSize)).Take((int)pageSize).AsNoTracking();

        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        var data = await query.ToListAsync();

        return data;
    }
}
