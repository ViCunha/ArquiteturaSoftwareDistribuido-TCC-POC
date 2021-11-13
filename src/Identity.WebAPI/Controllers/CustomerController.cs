using Identity.Application.Interfaces;
using Identity.Domain.Models;
using Identity.Domain.Models.APIResponse;
using Identity.Domain.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Threading.Tasks;

namespace Identity.WebAPI.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/private/[controller]/v{version:apiVersion}")]
    public class CustomerController : ControllerBase
    {
        //
        private readonly ICustomerApplicationServices _customerApplicationServices;
        private readonly IConfiguration _configuration;

        //
        public CustomerController
            (
                ICustomerApplicationServices customerApplicationServices
                ,
                IConfiguration configuration
            )
        {
            this._customerApplicationServices = customerApplicationServices;
            this._configuration = configuration;
        }

        //
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIResponseContent))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(APIResponseContent))]
        public async Task<ActionResult<CustomerDTO>> GetCustomerAsync(Guid id)
        {
            var result = await _customerApplicationServices.CustomerQueryOrchestrator.GetCustomerByIdAsync(id);

            if (result is APIResponseContentFailure)
            {
                BadRequest((APIResponseContentFailure)result);
            }

            return Ok((APIResponseContentSuccess)result);
        }

        //
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIResponseContent))]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomersAsync()
        {
            var result = await _customerApplicationServices.CustomerQueryOrchestrator.GetAllCustomersAsync();

            if (result is APIResponseContentFailure)
            {
                BadRequest((APIResponseContentFailure)result);
            }

            return Ok((APIResponseContentSuccess) result);
        }

        //
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(APIResponseContent))]
        public async Task<ActionResult<Customer>> CreateNewCustomerAsync (CustomerDTO customerDTO)
        {

            var result = await _customerApplicationServices.CustomerCommandOrchestrator.CreateNewCustomerAsync(customerDTO);

            if (result is APIResponseContentFailure)
            {
                return BadRequest((APIResponseContentFailure)result);
            }

            return Ok((APIResponseContentSuccess)result);
        }



        public async Task<ActionResult<>>
    }
}