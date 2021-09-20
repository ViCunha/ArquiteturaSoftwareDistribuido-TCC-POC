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
        public static IServiceCollection AddInfrastructurePersistenceServiceCollection(this IServiceCollection services)
        {

            return services;
        }
    }
}
