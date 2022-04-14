using System;

namespace Identity.Domain.Models.Events
{
    public class Event : Message
    {

        public DateTime TimeStamp { get; set; }

        public Event()
        {
            TimeStamp = DateTime.UtcNow;
        }
    }
}
