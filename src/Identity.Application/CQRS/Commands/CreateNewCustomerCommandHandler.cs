using AutoMapper;
using FluentValidation.Results;
using Identity.Domain.Models;
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
        
        private readonly IMapper _autoMapper;

        public CreateNewCustomerCommandHandler
            (
            ICustomerPersistenceServices PersistenceServicesCustomer
            ,
            IMapper autoMapper
            )
        {
            this._persistenceServicesCustomer = PersistenceServicesCustomer;
            this._autoMapper = autoMapper;
        }

        public async Task<ValidationResult> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken)
        {
            //
            var newValidationResult = new ValidationResult();
            var customer = _autoMapper.Map<Customer>(request.CustomerDTO);
            



            
            //
            var resultGetCustomersByIdAsync = await _persistenceServicesCustomer.GetCustomersByIdAsync(customer.Id);
            if (resultGetCustomersByIdAsync != null)
            {
                newValidationResult.Errors.Add(new ValidationFailure("Id", $"This {nameof(customer.Id)} already exist"));
                return newValidationResult;
            }

            //
            var customerValidationResults = await (new CustomerValidator().ValidateAsync(customer));
            if (!customerValidationResults.IsValid)
            {
                return customerValidationResults;
            }

            //
            var result = await _persistenceServicesCustomer.CreateNewCustomerAsync(customer, request.CustomerDTO.TPCId);
            if (result != 1)
            {
                newValidationResult.Errors.Add(new ValidationFailure("", ""));
                return newValidationResult;
            }

            return newValidationResult;
        }
    }
}
