﻿using Identity.Domain.Models;
using Identity.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Queries
{
    public class GetAllCustomersQuery : IGetAllCustomersQuery
    {
        private readonly ICustomerPersistenceServices _PersistenceServicesCustomer;

        public GetAllCustomersQuery(ICustomerPersistenceServices PersistenceServicesCustomer)
        {
            this._PersistenceServicesCustomer = PersistenceServicesCustomer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _PersistenceServicesCustomer.GetAllCustomers();
        }
    }
}
