using System;
using System.IO.Compression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using InterestCalculation.Domain;
using InterestCalculation.Web.Extensions;
using InterestCalculation.Web.Service;

namespace InterestCalculation.Web
{
    public class Startup
    {
        private IConfiguration _configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(
                options => options.Level = CompressionLevel.Optimal);

            services
                .AddCorsAll("AllowAll")
                .AddApplicationServiceDependency()
                .AddTnfAspNetCore()
                .AddInterestRateClient(_configuration["ServicesConfiguration:InterestRateEndpoint:Uri"])
                .AddResponseCompression(options =>
                {
                    options.Providers.Add<GzipCompressionProvider>();
                    options.EnableForHttps = true;
                });

            services.AddSwaggerDocumentation();

            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = "X-CSRF-TOKEN-GOTNEXT-COOKIE";
                options.HeaderName = "X-CSRF-TOKEN-GOTNEXT-HEADER";
                options.SuppressXFrameOptionsHeader = false;
            })
            .AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(opts =>
            {
                opts.SerializerSettings.NullValueHandling =
                    Newtonsoft.Json.NullValueHandling.Ignore;
            });

            var serviceProvider = services.BuildServiceProvider();

            ServiceLocator.SetLocatorProvider(serviceProvider);

            return serviceProvider;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger, IHttpContextAccessor contextAccessor)
        {
            app.UseCors("AllowAll");

            app.UseTnfAspNetCore(options =>
            {                
                options.UseDomainLocalization();
            });

            app.UsePathBase("/interestCalculation");

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwaggerDocumentation();

            app.UseMvcWithDefaultRoute();

            app.UseResponseCompression();

            app.Run(context =>
            {
                context.Response.Redirect("/interestCalculation/swagger");
                return Task.CompletedTask;
            });
        }

    }
}
