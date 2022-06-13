using Convey.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convey.Persistence.EFCore.Postgres.Internals
{
    internal class UnitOfWorkEf<TContext> : IUnitOfWork where TContext : DbContext
    {
        #region Private Field
        private readonly TContext _context;
        #endregion

        public UnitOfWorkEf(TContext context)
        {
            _context = context;
        }

        public IRepository<TEntity,TId> GetRepository<TEntity, TId>() where TEntity : class, IHaveIdentity<TId>
        {
            return new Repository<TEntity, TId>(_context);
        }


        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public async Task BeginTranAsync(CancellationToken cancellationToken = default)
        {
            await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public int CommitTran()
        {
            var result = _context.SaveChanges();
            _context.Database.CommitTransaction();
            return result;
        }

        public async Task<int> CommitTranAsync(CancellationToken cancellationToken = default)
        {
            var result = await _context.SaveChangesAsync(cancellationToken);
            await _context.Database.CommitTransactionAsync(cancellationToken);
            return result;
        }

        public void RollBackTran()
        {
            _context.Database.RollbackTransaction();
        }

        public async Task RollBackTranAsync(CancellationToken cancellation = default)
        {
            await _context.Database.RollbackTransactionAsync(cancellation);
        }

        #region dispose

        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                // TODO: dispose managed state(managed object)
                _context.Dispose();
            }


            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null
            _disposed = true;
        }


        ~UnitOfWorkEf() => Dispose(false);


        #endregion
    }
}
