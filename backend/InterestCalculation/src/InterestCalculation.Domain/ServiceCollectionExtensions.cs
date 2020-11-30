using InterestCalculation.Domain.Queries.Request;
using MediatR;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainDependency(this IServiceCollection services)
        {
            services.ConfigureMediatR();

            return services;
        }

        private static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(InterestCalculationCommand).GetTypeInfo().Assembly);
        }
    }
}
