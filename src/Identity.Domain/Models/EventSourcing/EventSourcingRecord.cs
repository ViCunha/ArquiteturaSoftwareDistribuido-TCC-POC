using Identity.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models.EventSourcing
{
    public class EventSourcingHistory : Entity, IAggregateRoot
    {
        //
        public DateTime MomentInTime { get; private set; }

        public Byte EventSourcingHistoryType { get; private set; }

        public string ObjectType { get; private set; }

        public string Data { get; private set; }

        //
        public EventSourcingHistory(Guid id, DateTime momentInTime, EventSourcingHistoryType eventSourcingHistoryType, string objectType, string data)
        {
            Id = id;
            MomentInTime = momentInTime;
            EventSourcingHistoryType = ((byte) eventSourcingHistoryType);
            Data = data;
            ObjectType = objectType;
        }

    }
}

