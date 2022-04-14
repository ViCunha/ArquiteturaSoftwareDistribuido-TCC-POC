using System;

namespace Identity.Domain.Models.Events
{
    public abstract class Message
    {
        public string Type { get; protected set; }

        public Guid AggregatedId { get; protected set; }

        public Message()
        {
            Type = GetType().Name;
            AggregatedId = Guid.NewGuid();
        }
    }
}
