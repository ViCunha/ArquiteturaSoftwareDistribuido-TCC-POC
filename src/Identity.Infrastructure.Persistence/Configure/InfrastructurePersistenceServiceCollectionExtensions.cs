using Identity.Domain.Interfaces;
using Identity.Infrastructure.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure.Persistence.Configure
{
    public static class InfrastructurePersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructurePersistenceServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {


            // Dependency Injection 
            {
                services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            }

            // DbContext 
            {
                services.AddDbContext<ApplicationDbContextCommands>
                    (options => options.UseSqlServer
                                    (
                                        configuration.GetConnectionString("ApplicationDbContextCommands")
                                        ,
                                        x => x.EnableRetryOnFailure()
                                    )
                                    );
            }

            return services;
        }
    }
}
