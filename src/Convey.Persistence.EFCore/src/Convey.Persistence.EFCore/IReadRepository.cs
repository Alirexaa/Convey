using Convey.Domain.Model;
using System.Linq.Expressions;

namespace Convey.Persistence.EFCore
{
    public interface IReadRepository<TEntity, in TId> where TEntity : class, IHaveIdentity<TId>
    {
        Task<TEntity?> FindByIdAsync(TId id, CancellationToken cancellationToken = default(CancellationToken));

        Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));

        Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));

        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<IReadOnlyList<TEntity>> RawQuery(string query, CancellationToken cancellationToken = default(CancellationToken), params object[] queryParams);
    }
}
