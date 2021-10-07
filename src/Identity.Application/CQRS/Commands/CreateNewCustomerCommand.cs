using FluentValidation.Results;
using Identity.Domain.Models;
using Identity.Domain.Models.Events;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Identity.Application.CQRS.Commands
{
    public class CreateNewCustomerCommand : Command, IRequest<ValidationResult> 
    {
        public Customer Customer { get; set; }

        public CreateNewCustomerCommand(Customer customer)
        {

            this.Customer = customer;
            this.AggregatedId = customer.Id;
        }
    }
}
