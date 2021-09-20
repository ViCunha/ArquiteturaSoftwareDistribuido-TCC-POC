using Identity.Application.CQRS.Queries;
using Identity.Infrastructure.Persistence.Configure;
using Identity.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Configure
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {
            // Dependency Injection # Local
            services.AddScoped<IGetAllCustomersQuery, GetAllCustomersQuery>();
            services.AddScoped<IRepositoryCustomer, RepositoryCustomer>();

            // Dependency Injection # Identity.Infrastructure.Persistence
            InfrastructurePersistenceServiceCollectionExtensions.AddInfrastructurePersistenceServiceCollection(services, configuration);

            return services;
        }
    }
}
