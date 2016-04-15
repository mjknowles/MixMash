using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.Contracts
{
    /// <summary>
    /// Aggregates are treated as one unit in DDD.
    /// Aggregate roots are the entry points of aggregates.
    /// Data access should only touch aggregate roots.
    /// </summary>
    public interface IAggregateRoot : IBusinessEntity
    {
    }
}
