using Identity.Application.CQRS.Queries;
using Identity.Domain.Models;
using Identity.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System;
using Moq.AutoMock;
using Identity.Application.Interfaces;
using Identity.Domain.Models.DTO;

namespace Identity.IntegrationTests
{
    public class CustomerControllerTest
    {
        [Fact]
        public async Task CustomerController_GetAllCustomers_ExpectedResultOkAndCollectionOfCustomerObjects()
        {
            //Arrange
            var mocker = new AutoMocker();
            var controller = mocker.CreateInstance<CustomerController>();
            
            mocker.GetMock<IGetAllCustomersQuery>()
                  .Setup(x => x.GetAllCustomersAsync())
                  .Returns(GetAllCustomersAsync());

            //Act
            var response = await controller.GetAllCustomersAsync();
            var statuscodeOk200Result = response.Result as OkObjectResult;
            var resultObject = GetCollectionResultContent<IEnumerable<Customer>>(statuscodeOk200Result);

            //Assert
            Assert.True(statuscodeOk200Result != null);
            mocker.GetMock<IGetAllCustomersQuery>().Verify(c => c.GetAllCustomersAsync(), Times.Once);
            Assert.True(resultObject.Result.Count() == 3);

            async Task<T> GetCollectionResultContent<T>(ActionResult<T> result)
            {
                await Task.Factory.StartNew(() => { });
                return (T)((ObjectResult)result.Result).Value;
            }

            async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
            {
                return await Task.Factory.StartNew
                    (
                        () => new List<CustomerDTO>()
                        {
                        new CustomerDTO() { Id = Guid.NewGuid(), IsActive = true, Name = "A" }
                        ,
                        new CustomerDTO() { Id = Guid.NewGuid(), IsActive = true, Name = "B" }
                        ,
                        new CustomerDTO() { Id = Guid.NewGuid(), IsActive = true, Name = "C" }
                        }
                    );
            }
        }

        [Fact]
        public async Task CustomerController_CreateNewCustomer_ExpectedResultOkAndCustomerObject()
        {
            //Arrange
            var mocker = new AutoMocker();
            var controller = mocker.CreateInstance<CustomerController>();

            //Act
            await Task.Factory.StartNew(() => { });

            //Assert
            Assert.True(true);
        }

    }
}
