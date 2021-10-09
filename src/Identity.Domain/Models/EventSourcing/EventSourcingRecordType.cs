using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models.EventSourcing
{
    public enum EventSourcingRecordType : Byte
    {
        Create = 1
        ,
        Update = 2
        ,
        Delete = 3
    }
}
