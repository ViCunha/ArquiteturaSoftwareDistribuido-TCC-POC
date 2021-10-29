using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public abstract class Entity

    {   //
        public Guid Id { get; private set; }

        public Boolean IsActive { get; private set; }

        public ulong DataVersion { get; private set; }

        //
        protected Entity()
        {
            Initialization();
        }

        public Entity(Guid id, bool isActive, ulong dataVersion)
            : this()
        {
            Id = id;
            IsActive = isActive;
            DataVersion = dataVersion;
        }

        private void Initialization()
        {
            Id = Guid.Empty;
            IsActive = true;
            DataVersion = 1;
        }

        public void SetIsActive(bool value)
        {
            this.IsActive = value;
        }
    }
}
