using InterestCalculation.Domain.Handlers;
using InterestCalculation.Tests.Mock;
using InterestRate.Client;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Shouldly;
using System.Threading.Tasks;
using Tnf.AspNetCore.TestBase;
using Tnf.Notifications;
using Xunit;
using static InterestCalculation.Domain.Queries.Request.InterestCalculationCommand.InterestCalculationValidator;

namespace InterestCalculation.Tests.UnitTests.Domain.Handlers
{
    public class InterestCalculationHandlerTest : TnfAspNetCoreIntegratedTestBase<StartupUnitPropertyTest>
    {
        private readonly INotificationHandler _notificationHandler;
        private readonly IInterestRateClient _interestRateClient;

        public InterestCalculationHandlerTest()
        {
            _notificationHandler = ServiceProvider.GetRequiredService<INotificationHandler>();
            _interestRateClient = Substitute.For<IInterestRateClient>();
        }

        [Fact]
        public void Shoud_Resolve_All()
        {
            ServiceProvider.GetService<INotificationHandler>().ShouldNotBeNull();
            ServiceProvider.GetService<IInterestRateClient>().ShouldNotBeNull();
        }

        private InterestCalculationHandler GetInterestCalculationHandler()
        {
            return new InterestCalculationHandler(
                _notificationHandler,
                _interestRateClient
                );
        }

        [Fact]
        public async Task Should_Raise_Notification_When_Command_Is_Invalid()
        {
            //parameters
            var command = InterestCalculationCommandMock.GetInvalidDto();

            //call
            var handler = GetInterestCalculationHandler();

            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.True(_notificationHandler.HasNotification());
            Assert.Contains(command.ValidationResult.Errors, e => e.CustomState is EntityError.InvalidInitialValue);
            Assert.Contains(command.ValidationResult.Errors, e => e.CustomState is EntityError.InvalidMonth);
        }

        [Fact]
        public async Task Should_Return_Calculated_Value()
        {
            //parameters
            var command = InterestCalculationCommandMock.GetValidDto();
            var value = 105.10;

            _interestRateClient.GetInterestRate().ReturnsForAnyArgs(x =>
            {
                return 0.01;
            });

            //call
            var handler = GetInterestCalculationHandler();

            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.False(_notificationHandler.HasNotification());
            Assert.Equal(value, result);
        }

        [Fact]
        public async Task Should_Return_Calculated_Another_Value()
        {
            //parameters
            var command = InterestCalculationCommandMock.GetAnotherValidDto();
            var value = 165.69;

            _interestRateClient.GetInterestRate().ReturnsForAnyArgs(x =>
            {
                return 0.01;
            });

            //call
            var handler = GetInterestCalculationHandler();

            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.False(_notificationHandler.HasNotification());
            Assert.Equal(value, result);
        }


        [Fact]
        public async Task Should_Return_Calculated_Different_Value()
        {
            //parameters
            var command = InterestCalculationCommandMock.GetDifferentValidDto();
            var value = 77.27;

            _interestRateClient.GetInterestRate().ReturnsForAnyArgs(x =>
            {
                return 0.01;
            });

            //call
            var handler = GetInterestCalculationHandler();

            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            Assert.False(_notificationHandler.HasNotification());
            Assert.Equal(value, result);
        }
    }
}
