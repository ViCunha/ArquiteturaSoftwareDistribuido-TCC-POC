using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models.DTO
{
    public class CustomerDTO 
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        public Boolean IsActive { get; set; }

    }
}
