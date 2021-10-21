using FluentValidation.Results;
using Identity.Domain.Models.Events;
using Identity.Domain.Models.Validations;
using Identity.Infrastructure.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Commands
{
    public class CreateNewCustomerCommandHandler : CommandHandler, IRequestHandler<CreateNewCustomerCommand, ValidationResult>
    {
        private readonly ICustomerPersistenceServices _persistenceServicesCustomer;

        public CreateNewCustomerCommandHandler(ICustomerPersistenceServices PersistenceServicesCustomer)
        {
            this._persistenceServicesCustomer = PersistenceServicesCustomer;
        }

        public async Task<ValidationResult> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken)
        {
            //
            var newValidationResult = new ValidationResult();
            var resultGetCustomersByIdAsync = await _persistenceServicesCustomer.GetCustomersByIdAsync(request.Customer.Id);
            if (resultGetCustomersByIdAsync != null)
            {
                newValidationResult.Errors.Add(new ValidationFailure("Id", $"This {nameof(request.Customer.Id)} already exist"));
                return newValidationResult;
            }

            //
            var customerValidationResults = await (new CustomerValidator().ValidateAsync(request.Customer));
            if (!customerValidationResults.IsValid)
            {
                return customerValidationResults;
            }

            //
            var result = await _persistenceServicesCustomer.CreateNewCustomerAsync(request.Customer);
            if (result != 1)
            {
                newValidationResult.Errors.Add(new ValidationFailure("", ""));
                return newValidationResult;
            }

            return newValidationResult;
        }
    }
}
