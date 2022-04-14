using Identity.Domain.Interfaces;
using System;

namespace Identity.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        protected Customer()
        { }

        public Customer(Guid Id, bool isActive, ulong dataVersion, string Name)
            : base(Id, isActive, dataVersion)
        {
            this.Name = Name;
        }

    }
}
