
namespace Identity.Application.Interfaces
{
    public interface ICustomerApplicationServices
    {

        public ICustomerQueryOrchestrator CustomerQueryOrchestrator { get; }


        public ICustomerCommandOrchestrator CustomerCommandOrchestrator { get; }

    }
}