using Identity.Infrastructure.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence.Configure
{
    public static class InfrastructurePersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructurePersistenceServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {

            // Dependecy Injection 
            {
                services.AddDbContext<ApplicationDBContextQueries>
                    (options => options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContextQueries")));
            }

            return services;
        }
    }
}
