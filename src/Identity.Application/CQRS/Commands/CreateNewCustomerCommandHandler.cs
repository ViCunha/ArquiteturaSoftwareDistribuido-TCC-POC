using Identity.Infrastructure.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Commands
{
    public class CreateNewCustomerCommandHandler : IRequestHandler<CreateNewCustomerCommand, bool>
    {
        private readonly ICustomerPersistenceServices _PersistenceServicesCustomer;

        public CreateNewCustomerCommandHandler(ICustomerPersistenceServices PersistenceServicesCustomer)
        {
            this._PersistenceServicesCustomer = PersistenceServicesCustomer;
        }

        public Task<bool> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
