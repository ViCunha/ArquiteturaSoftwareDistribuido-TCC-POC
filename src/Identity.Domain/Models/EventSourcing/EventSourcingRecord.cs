using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models.EventSourcing
{
    public class EventSourcingRecord
    {
        public Guid Id { get; set; }

        public DateTime Event { get; set; }

        public int MyProperty { get; set; }
    }
}


/*
 * 
           Guid: EventID
            Int: Sequence
            DateTimeUTC: Event
            type: Create, Update, Delete
            String: JSON* 
 * */