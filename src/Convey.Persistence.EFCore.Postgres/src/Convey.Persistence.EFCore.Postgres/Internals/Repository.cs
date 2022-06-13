//using Convey.Domain.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace Convey.Persistence.EFCore.Postgres.Internals
//{
//    internal class Repository :IRepository<IEntity>
//    {
//        public Task<object> AddAsync(object entity, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task DeleteAsync(Expression<Func<object, bool>> predicate, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task DeleteAsync(object entity, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task DeleteRangeAsync(IReadOnlyList<object> entities, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IReadOnlyList<object>> FindAsync(Expression<Func<object, bool>> predicate, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<object?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<object?> FindOneAsync(Expression<Func<object, bool>> predicate, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IReadOnlyList<object>> GetAllAsync(CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IReadOnlyList<object>> RawQuery(string query, CancellationToken cancellationToken = default, params object[] queryParams)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<object> UpdateAsync(object entity, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
