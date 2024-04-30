using System.Linq.Expressions;
using ELearn.Core;
using Microsoft.EntityFrameworkCore;

namespace ELearn.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context;

    public Repository(AppDbContext context)
    {
        Context = context;
    }

    public async Task<TEntity> GetAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
    }

    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await Context.Set<TEntity>().AddRangeAsync(entities);
    }

    public async Task RemoveAsync(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        await Task.CompletedTask;
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        Context.Set<TEntity>().RemoveRange(entities);
        await Task.CompletedTask;
    }
}