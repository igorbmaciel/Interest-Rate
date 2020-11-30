using InterestRate.Client;
using InterestRate.Client.Services;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInterestRateClient(this IServiceCollection services, string urlAPI)
        {
            services.AddHttpClient<IInterestRateClient, InterestRateClient>(client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(urlAPI);
            });

            return services;
        }
    }
}

