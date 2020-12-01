using System;
using System.IO;
using InterestCalculation.Domain;
using InterestCalculation.Tests.Mock;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tnf.Notifications;
using Tnf.TestBase;
using Xunit;
using static InterestCalculation.Domain.Queries.Request.InterestCalculationCommand.InterestCalculationValidator;

namespace InterestCalculation.Tests.UnitTests.Domain.Queries.Request
{
    public class InterestCalculationCommandTest : TnfIntegratedTestBase
    {
        protected override void PreInitialize(IServiceCollection services)
        {
            base.PreInitialize(services);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            services.AddDomainDependency();
        }

        protected override void PostInitialize(IServiceProvider provider)
        {
            base.PostInitialize(provider);

            provider.ConfigureTnf(config =>
            {
                config.UseDomainLocalization();
            });
        }

        [Fact]
        public void Should_Not_Have_Validation_Error_When_Valid_Command()
        {
            var notificationHandler = ServiceProvider.GetRequiredService<INotificationHandler>();
            var command = InterestCalculationCommandMock.GetValidDto();

            //call
            command.IsValid();

            //assert
            Assert.DoesNotContain(command.ValidationResult.Errors, e => e.CustomState is EntityError.InvalidInitialValue);
            Assert.DoesNotContain(command.ValidationResult.Errors, e => e.CustomState is EntityError.InvalidMonth);
        }

        [Fact]
        public void ShouldHave_Validation_Error_When_Invalid_Command()
        {
            var notificationHandler = ServiceProvider.GetRequiredService<INotificationHandler>();
            var command = InterestCalculationCommandMock.GetInvalidDto();

            //call
            command.IsValid();

            //assert
            Assert.Contains(command.ValidationResult.Errors, e => e.CustomState is EntityError.InvalidInitialValue);
            Assert.Contains(command.ValidationResult.Errors, e => e.CustomState is EntityError.InvalidMonth);
        }

    }
}
