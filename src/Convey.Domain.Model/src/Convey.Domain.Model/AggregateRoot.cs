namespace Convey.Domain.Model
{
    public abstract class AggregateRoot<TId> : Entity<TId>,/* IAggregate<TId>,*/ IEntity<TId>, IHaveIdentity<TId>, IHaveIdentity, IHaveCreator/*, IHaveAggregate*/, IHaveVersion
    {
        //private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        //public IEnumerable<IDomainEvent> Events => _events;
        public AggregateId<TId> Id { get; protected set; }

        public long CurrentVersion { get; private set; } = -1L;

        public long OrginalVersion { get; private set; } = -1L;
        //public int Version { get; protected set; }

        //protected void AddEvent(IDomainEvent @event)
        //{
        //    _events.Add(@event);
        //}

        //public void ClearEvents() => _events.Clear();
    }

    public abstract class AggregateRoot : AggregateRoot<Guid>
    {
        public AggregateId Id { get; protected set; }

    }
}
