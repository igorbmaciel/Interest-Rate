using InterestRate.Application.Interfaces;
using InterestRate.Application.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServiceDependency(this IServiceCollection services)
        {            
            services.AddTransient<IInterestRateAppService, InterestRateAppService>();          

            return services;
        }
    }
}
