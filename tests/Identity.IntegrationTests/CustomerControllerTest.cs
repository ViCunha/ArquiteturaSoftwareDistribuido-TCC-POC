using Identity.Application.CQRS.Queries;
using Identity.Domain.Model;
using Identity.WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System;

namespace Identity.IntegrationTests
{
    public class CustomerControllerTest
    {
        [Fact]
        public async Task CustomerController_GetAllCustomers_ExpectedResultOkAndCollectionOfObjects()
        {
            //Arrange
            var getAllCustomersQuery = new Mock<IGetAllCustomersQuery>();
            getAllCustomersQuery.Setup(x => x.GetAllCustomers())
                                .Returns(GetAllCustomers());
            var controller = new CustomerController(getAllCustomersQuery.Object);

            //Act
            var response = await controller.GetAllCustomers();
            var statuscodeOk200Result = response.Result as OkObjectResult;
            var resultObject = GetCollectionResultContent<IEnumerable<Customer>>(statuscodeOk200Result);

            //Assert
            Assert.True(statuscodeOk200Result != null);
            getAllCustomersQuery.Verify(c => c.GetAllCustomers(), Times.Once);
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
