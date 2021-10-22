using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces
{
    public interface ITransactionProcessingControl
    {
        public Guid TPCId { get; set; }
    }
}
