﻿using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Customer> CustomerRepository { get; }

        int Save();

        Task<int> SaveAsync();
    }
}
