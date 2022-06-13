using Convey.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convey.Persistence.EFCore
{
    public interface IRepository<TEntity> : IRepository<TEntity, Guid>, IReadRepository<TEntity, Guid>, IWriteRepository<TEntity, Guid>, IDisposable where TEntity : class, IHaveIdentity<Guid>
    {
    }

    public interface IRepository<TEntity, in TId> : IReadRepository<TEntity, TId>, IWriteRepository<TEntity, TId>, IDisposable where TEntity : class, IHaveIdentity<TId>
    {
    }
}
