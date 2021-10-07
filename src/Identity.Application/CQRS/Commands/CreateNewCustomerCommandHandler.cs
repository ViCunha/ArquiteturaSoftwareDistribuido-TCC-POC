using Identity.Domain.Models.Events;
using Identity.Domain.Models.Validations;
using Identity.Infrastructure.Persistence.Interfaces;
using Identity.Infrastructure.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Commands
{
    public class CreateNewCustomerCommandHandler : CommandHandler, IRequestHandler<CreateNewCustomerCommand, bool>
    {
        private readonly ICustomerPersistenceServices _persistenceServicesCustomer;

        public CreateNewCustomerCommandHandler(ICustomerPersistenceServices PersistenceServicesCustomer)
        {
            this._persistenceServicesCustomer = PersistenceServicesCustomer;
        }

        public async Task<bool> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerValidator = new CustomerValidator();
            var customerValidatorResult = await customerValidator.ValidateAsync(request.Customer);

            if (!customerValidatorResult.IsValid)
            {
                return false;
            }

            var result = await _persistenceServicesCustomer.CreateNewCustomerAsync(request.Customer);
            if (result != 1)
            {
                return false;
            }


            return true;
        }
    }
}
