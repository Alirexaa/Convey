using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convey.Domain.Model;

public interface IHaveIdentity
{
    object Id { get; }
}

public interface IHaveIdentity<out TId> : IHaveIdentity
{
    new TId Id { get; }

    object IHaveIdentity.Id => Id;
}
