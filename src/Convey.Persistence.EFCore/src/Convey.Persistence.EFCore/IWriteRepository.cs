using Convey.Domain.Model;
using System.Linq.Expressions;

namespace Convey.Persistence.EFCore
{
    public interface IWriteRepository<TEntity, in TId> where TEntity : class, IHaveIdentity<TId>
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteRangeAsync(IReadOnlyList<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteByIdAsync(TId id, CancellationToken cancellationToken = default(CancellationToken));
    }
}
