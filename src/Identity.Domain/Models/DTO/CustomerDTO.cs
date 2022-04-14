using Identity.Domain.Interfaces;
using System;

namespace Identity.Domain.Models.DTO
{
    public class CustomerDTO : ITransactionProcessingControl
    {
        //
        public Guid TPCId { get; set; }

        //
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Boolean IsActive { get; set; }

    }
}
