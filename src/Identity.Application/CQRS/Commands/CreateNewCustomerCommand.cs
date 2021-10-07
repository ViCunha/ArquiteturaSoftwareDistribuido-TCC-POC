using Identity.Domain.Models;
using Identity.Domain.Models.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Commands
{
    public class CreateNewCustomerCommand : Command, IRequest<bool> 
    {
        public Customer Customer { get; set; }

        public CreateNewCustomerCommand(Customer customer)
        {

            this.Customer = customer;
            this.AggregatedId = customer.Id;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>().AsEnumerable();
        }

    }
}
