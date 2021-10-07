using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public abstract class Entity 
    {
        public Guid Id { get; protected set; }

        public Boolean IsActive { get; protected set; }

        public void SetIsActive(bool value)
        {
            this.IsActive = value;
        }

    }
}
