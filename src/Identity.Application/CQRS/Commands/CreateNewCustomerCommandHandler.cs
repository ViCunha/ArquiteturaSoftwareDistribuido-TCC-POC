using Identity.Domain.Models.Events;
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
    public class CreateNewCustomerCommandHandler : CommandHandler, IRequestHandler<CreateNewCustomerCommand, IEnumerable<ValidationResult>>
    {
        private readonly ICustomerPersistenceServices _persistenceServicesCustomer;

        public CreateNewCustomerCommandHandler(ICustomerPersistenceServices PersistenceServicesCustomer)
        {
            this._persistenceServicesCustomer = PersistenceServicesCustomer;
        }

        public async Task<IEnumerable<ValidationResult>> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken)
        {
            //if (request.Validate(null).Count() == 0)
            //{
            //    AddValidationResult("#01");
            //    return ValidationResult;
            //}

            var result = await _persistenceServicesCustomer.CreateNewCustomerAsync(request.Customer);

            if (result != 1)
            {
                AddValidationResult("#02");
                return ValidationResult;
            }


            return null;
        }
    }
}
