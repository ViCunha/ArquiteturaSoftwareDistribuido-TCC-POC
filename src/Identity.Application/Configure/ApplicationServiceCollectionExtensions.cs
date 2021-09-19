using Identity.Application.CQRS.Queries;
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
            // Dependency Injection
            services.AddScoped<IGetAllCustomersQuery, GetAllCustomersQuery>();

            return services;
        }
    }
}
