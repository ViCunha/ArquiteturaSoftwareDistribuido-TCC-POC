using System;

namespace Identity.Domain.Models.EventSourcing
{
    public enum EventSourcingHistoryType : Byte
    {
        Create = 1
        ,
        Update = 2
        ,
        Delete = 3
    }
}
