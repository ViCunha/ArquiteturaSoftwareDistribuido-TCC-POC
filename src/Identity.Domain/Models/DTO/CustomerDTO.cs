using Identity.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
