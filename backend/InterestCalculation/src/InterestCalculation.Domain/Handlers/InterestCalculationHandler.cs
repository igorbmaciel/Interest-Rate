using InterestCalculation.Domain.Base;
using InterestCalculation.Domain.Queries.Request;
using InterestRate.Client;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tnf.Notifications;

namespace InterestCalculation.Domain.Handlers
{
    public class InterestCalculationHandler : BaseRequestHandler, IRequestHandler<InterestCalculationCommand, double>
    {
        private readonly IInterestRateClient _interestRateClient;

        public InterestCalculationHandler(
            INotificationHandler notification, IInterestRateClient interestRateClient
            ) : base(notification) 
        {
            _interestRateClient = interestRateClient;
        }

        public async Task<double> Handle(InterestCalculationCommand command, CancellationToken cancellationToken)
        {
            if (!IsValid(command))
                return default;

            var rate = await _interestRateClient.GetInterestRate();

            var finalResult = CalculateInterestRate(command.InitialValue, command.Month, rate);

            return finalResult;
        }

        private double CalculateInterestRate(double initialValue, int month, double rate)
        {
            var value = Math.Pow((1 + rate), month);
            var result = initialValue * value;
            return Math.Truncate(100 * result) / 100;
        }
    }
}
