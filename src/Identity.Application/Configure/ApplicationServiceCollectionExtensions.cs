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
        public static IServiceCollection AddApplicationServiceCollection(this IServiceCollection services)
        {

            return services;
        }
    }
}
