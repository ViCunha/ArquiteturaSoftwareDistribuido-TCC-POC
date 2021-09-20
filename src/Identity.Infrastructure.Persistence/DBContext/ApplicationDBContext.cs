using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.DBContext
{
    public class ApplicationDBContextQueries : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        public ApplicationDBContextQueries(DbContextOptions<ApplicationDBContextQueries> options)
            : base(options)
        {

        }
    }
}
