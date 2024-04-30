using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ELearn.Core;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    // This method was not in the videos, but I thought it would be useful to add.
    Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
        
    Task RemoveAsync(TEntity entity);
    Task RemoveRangeAsync(IEnumerable<TEntity> entities);
}