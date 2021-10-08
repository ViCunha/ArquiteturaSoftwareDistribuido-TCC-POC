using AutoMapper;
using Identity.Application.CQRS.Commands;
using Identity.Application.Interfaces;
using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using Identity.Domain.Models.APIResponse;
using Identity.Domain.Models.DTO;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Application.Models
{
    public class CustomerCommandOrchestrator : ICustomerCommandOrchestrator
    {
        private readonly IMediatRHandler _mediatRHandler;

        private readonly IMapper _autoMapper;

        public CustomerCommandOrchestrator
            (
                IMediatRHandler mediatRHandler
                ,
                IMapper autoMapper
            )
        {
            this._mediatRHandler = mediatRHandler;
            this._autoMapper = autoMapper;
        }


        public async Task<APIResponseContent> CreateNewCustomerAsync(CustomerDTO customerDTO)
        {
            var result = await _mediatRHandler.SendCommandAsync(new CreateNewCustomerCommand(_autoMapper.Map<Customer>(customerDTO)));
            if (result.Errors.Count > 0)
            {
                return new APIResponseContentFailure(StatusCodes.Status400BadRequest, result.Errors.Select(x =>x.ErrorMessage).ToList());
            }
            
            return new APIResponseContentSuccess(StatusCodes.Status400BadRequest, customerDTO); 
        }

    }
}