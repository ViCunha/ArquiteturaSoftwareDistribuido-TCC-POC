using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models.DTO
{
    public class CustomerJWT
    {
        public Customer Customer { get; set; }
        public JWTSettingsDTO JWTSettingsDTO { get; set; }
    }
}
