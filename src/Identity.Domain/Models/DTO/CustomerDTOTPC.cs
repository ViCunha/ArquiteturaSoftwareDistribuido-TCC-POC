using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models.DTO
{
    public class CustomerDTOTPC
    {
        public Guid Id { get; private set; }

        public CustomerDTO CustomerDTO { get; private set; }

    }
}
