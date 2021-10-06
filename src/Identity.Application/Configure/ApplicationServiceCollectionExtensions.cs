using Identity.Application.CQRS.Commands;
using Identity.Application.CQRS.Queries;
using Identity.Application.Interfaces;
using Identity.Application.MediatR;
using Identity.Application.Models;
using Identity.Domain.Interfaces;
using Identity.Infrastructure.Persistence.Configure;
using Identity.Infrastructure.Persistence.Interfaces;
using Identity.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Configure
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {

            // Dependency Injection # MediatR # Local
            services.AddMediatR(typeof(ApplicationServiceCollectionExtensions));

            // Dependency Injection # AutoMapper # Local
            services.AddAutoMapper(typeof(CustomerAutoMapperProfile));

            // Dependency Injection # Local
            services.AddScoped<IMediatRHandler, MediatRHandler>();
            services.AddScoped<IRequestHandler<CreateNewCustomerCommand, IEnumerable<ValidationResult>>, CreateNewCustomerCommandHandler>();
            services.AddScoped<ICustomerApplicationServices, CustomerApplicationServices>();
            services.AddScoped<ICreateNewCustomerOrchestrator, CreateNewCustomerOrchestrator>();
            services.AddScoped<IGetAllCustomersQuery, GetAllCustomersQuery>();
            services.AddScoped<ICustomerPersistenceServices, CustomerPersistenceServices>();

            // Dependency Injection # Identity.Infrastructure.Persistence
            InfrastructurePersistenceServiceCollectionExtensions.AddInfrastructurePersistenceServiceCollection(services, configuration);

            return services;
        }
    }
}
