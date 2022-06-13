namespace Convey.Domain.Model;

public interface IEntity<out TId> : IHaveIdentity<TId>, IHaveIdentity, IHaveCreator
{
}

public interface IEntity : IHaveIdentity<Guid>, IHaveIdentity, IHaveCreator
{
}