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
                  .Setup(x => x.GetAllCustomers())
                  .Returns(GetAllCustomers());

            //Act
            var response = await controller.GetAllCustomers();
            var statuscodeOk200Result = response.Result as OkObjectResult;
            var resultObject = GetCollectionResultContent<IEnumerable<Customer>>(statuscodeOk200Result);

            //Assert
            Assert.True(statuscodeOk200Result != null);
            mocker.GetMock<IGetAllCustomersQuery>().Verify(c => c.GetAllCustomers(), Times.Once);
            Assert.True(resultObject.Result.Count() == 3);

            async static Task<T> GetCollectionResultContent<T>(ActionResult<T> result)
            {
                await Task.Factory.StartNew(() => { });
                return (T)((ObjectResult)result.Result).Value;
            }

            async static Task<IEnumerable<Customer>> GetAllCustomers()
            {
                return await Task.Factory.StartNew
                    (
                        () => new List<Customer>()
                        {
                        new Customer() { Id = Guid.NewGuid(), isActive = true, Name = "a" }
                        ,
                        new Customer() { Id = Guid.NewGuid(), isActive = true, Name = "b" }
                        ,
                        new Customer() { Id = Guid.NewGuid(), isActive = true, Name = "c" }
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
            mocker.GetMock<IGetAllCustomersQuery>()
                .Setup(x => x.GetAllCustomers())
                .Returns(GetAllCustomers());

            //Act
            var response = await controller.GetAllCustomers();
            var statuscodeOk200Result = response.Result as OkObjectResult;
            var resultObject = GetCollectionResultContent<IEnumerable<Customer>>(statuscodeOk200Result);

            //Assert
            Assert.True(statuscodeOk200Result != null);
            mocker.GetMock<IGetAllCustomersQuery>().Verify(c => c.GetAllCustomers(), Times.Once);
            Assert.True(resultObject.Result.Count() == 3);

            async static Task<T> GetCollectionResultContent<T>(ActionResult<T> result)
            {
                await Task.Factory.StartNew(() => { });
                return (T)((ObjectResult)result.Result).Value;
            }

            async static Task<IEnumerable<Customer>> GetAllCustomers()
            {
                return await Task.Factory.StartNew
                (
                    () => new List<Customer>()
                    {
                        new Customer() { Id = Guid.NewGuid(), isActive = true, Name = "a" }
                        ,
                        new Customer() { Id = Guid.NewGuid(), isActive = true, Name = "b" }
                        ,
                        new Customer() { Id = Guid.NewGuid(), isActive = true, Name = "c" }
                    }
                );
            }
        }

    }
}
