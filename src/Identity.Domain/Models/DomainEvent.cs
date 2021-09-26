using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregatedId)
        {
            this.AggregatedId = aggregatedId;
        }
    }
}
