using Identity.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models.EventSourcing
{
    public class EventSourcingRecord : Base, IAggregateRoot
    {
        //
        public Guid Id { get; private set; }

        public DateTime MomentInTime { get; private set; }

        public EventSourcingRecordType Type { get; private set; }

        public string Data { get; private set; }

        //
        public EventSourcingRecord(Guid id, DateTime momentInTime, EventSourcingRecordType type, string data)
        {
            Id = id;
            MomentInTime = momentInTime;
            Type = type;
            Data = data;
        }

    }
}

