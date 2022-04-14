using Identity.Domain.Interfaces;
using System;

namespace Identity.Domain.Models.EventSourcing
{
    public class EventSourcingHistory : Entity, IAggregateRoot
    {

        //
        public DateTime MomentInTime { get; private set; }

        public Byte EventSourcingHistoryType { get; private set; }

        public Guid ObjectId { get; set; }

        public string ObjectType { get; private set; }

        public string Data { get; private set; }


        //
        public EventSourcingHistory(Guid id, DateTime momentInTime, Byte eventSourcingHistoryType, Guid objectId, string objectType, string data)
            : base(id, true, 1)
        {
            MomentInTime = momentInTime;
            EventSourcingHistoryType = eventSourcingHistoryType;
            ObjectId = objectId;
            ObjectType = objectType;
            Data = data;
        }

    }
}

