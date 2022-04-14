using System;

namespace Identity.Domain.Interfaces
{
    public interface ITransactionProcessingControl
    {
        public Guid TPCId { get; set; }
    }
}
