using Identity.Application.Interfaces;
using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using Identity.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Commands
{
    public class CreateNewCustomerOrchestrator : ICreateNewCustomerOrchestrator
    {
        private readonly IMediatRHandler _mediatRHandler;

        public CreateNewCustomerOrchestrator
            (
                IMediatRHandler mediatRHandler
            )
        {
            this._mediatRHandler = mediatRHandler;
        }

        public async Task<CustomerDTO> CreateNewCustomer(CustomerDTO customer)
        {


            var result = await _mediatRHandler.SendCommand(new CreateNewCustomerCommand(null));
            return null;

        }

    }
}