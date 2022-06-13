using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convey.Domain.Model
{
    public abstract class Entity<TId> : IEntity<TId>, IHaveIdentity<TId>, IHaveIdentity
    {
        public TId Id { get; protected set; }

        public DateTime CreateAt { get; protected set; }

        public long? CreateBy { get; protected set; }

        protected Entity(TId id)
        {
            Id = id;
        }

        protected Entity()
        {
        }
    }
}
