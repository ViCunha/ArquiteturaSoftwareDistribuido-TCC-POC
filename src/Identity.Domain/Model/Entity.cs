using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Model
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public Boolean isActive { get; private set; }

    }
}
