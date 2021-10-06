using AutoMapper;
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

        private readonly IMapper _autoMapper;

        public CreateNewCustomerOrchestrator
            (
                IMediatRHandler mediatRHandler
                ,
                IMapper autoMapper
            )
        {
            this._mediatRHandler = mediatRHandler;
            this._autoMapper = autoMapper;
        }


        public async Task<CustomerDTO> CreateNewCustomerAsync(CustomerDTO customerDTO)
        {
            var result = await _mediatRHandler.SendCommandAsync(new CreateNewCustomerCommand(_autoMapper.Map<Customer>(customerDTO)));

            if (result != null)
            {

            }

            return _autoMapper.Map<CustomerDTO>(customerDTO);
        }

    }
}