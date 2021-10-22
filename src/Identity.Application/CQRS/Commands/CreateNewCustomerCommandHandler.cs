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
        private readonly ICustomerPersistenceServices _customerPersistenceServices;
        private readonly ITransactionProcessingControlServices _transactionProcessingControlServices;
        private readonly IMapper _autoMapper;

        public CreateNewCustomerCommandHandler
            (
            ICustomerPersistenceServices customerPersistenceServices
            ,
            ITransactionProcessingControlServices transactionProcessingControlServices
            ,
            IMapper autoMapper
            )
        {
            this._customerPersistenceServices = customerPersistenceServices;
            this._transactionProcessingControlServices = transactionProcessingControlServices;
            this._autoMapper = autoMapper;
        }

        public async Task<ValidationResult> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken)
        {
            //
            var newValidationResult = new ValidationResult();

            //
            var resultOfTransactionProcessingControlServices = await _transactionProcessingControlServices.GetTransactionProcessingControlByIdAsync(request.CustomerDTO.TPCId);
            if (resultOfTransactionProcessingControlServices != null)
            {
                newValidationResult.Errors.Add(new ValidationFailure("TPCId", $"This Transaction was already processed"));
                return newValidationResult;
            }

            //
            var customer = _autoMapper.Map<Customer>(request.CustomerDTO);
            var resultOfGetCustomersByIdAsync = await _customerPersistenceServices.GetCustomersByIdAsync(customer.Id);
            if (resultOfGetCustomersByIdAsync != null)
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
            var result = await _customerPersistenceServices.CreateNewCustomerAsync(customer, request.CustomerDTO.TPCId);
            if (result != 1)
            {
                newValidationResult.Errors.Add(new ValidationFailure("Unknown Failure", ""));
                return newValidationResult;
            }

            return newValidationResult;
        }
    }
}
