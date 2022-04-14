using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Persistence.DBContext
{
    public class ApplicationDBContextQueries : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDBContextQueries(DbContextOptions<ApplicationDBContextQueries> options)
            : base(options)
        {

        }
    }
}
