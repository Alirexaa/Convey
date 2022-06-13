namespace Convey.Persistence.EFCore
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
    public interface IUnitOfWork<out TContext> : IUnitOfWork, IDisposable where TContext : class
    {
        TContext Context { get; }
    }
}
