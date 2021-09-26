using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.DBContext
{
    public class ApplicationDBContextCommands : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDBContextCommands(DbContextOptions<ApplicationDBContextCommands> options)
            : base(options)
        {

        }
    }
}
