using FluentValidation.Results;
using Identity.Domain.Models.DTO;
using Identity.Domain.Models.Events;
using MediatR;

namespace Identity.Application.CQRS.Commands
{
    public class CreateNewCustomerCommand : Command, IRequest<ValidationResult>
    {
        public CustomerDTO CustomerDTO { get; set; }

        public CreateNewCustomerCommand(CustomerDTO customerDTO)
        {
            this.CustomerDTO = customerDTO;

            //TODO: Why/Where should I use AggregatedId?
            this.AggregatedId = customerDTO.Id;
        }
    }
}
