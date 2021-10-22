using Identity.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class TransactionProcessingControlHistory : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }

        public DateTime MomentInTime { get; private set; }
     
        protected TransactionProcessingControlHistory()
        { }

        public TransactionProcessingControlHistory(Guid id, DateTime momentInTime)
        {
            this.Id = id;
            this.MomentInTime = momentInTime;
        }

    }
}
