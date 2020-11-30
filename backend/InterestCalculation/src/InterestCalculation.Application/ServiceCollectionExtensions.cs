using InterestCalculation.Application.Interfaces;
using InterestCalculation.Application.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServiceDependency(this IServiceCollection services)
        {
            services
                .AddDomainDependency();

            services.AddTransient<IInterestCalculationAppService, InterestCalculationAppService>();
            services.AddTransient<IShowMeTheCode, ShowMeTheCode>();

            return services;
        }
    }
}

