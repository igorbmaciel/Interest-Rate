using InterestCalculation.Application.Interfaces;
using InterestCalculation.Domain.Queries.Request;
using MediatR;
using System.Threading.Tasks;
using Tnf.Notifications;

namespace InterestCalculation.Application.Services
{
    public class InterestCalculationAppService : ApplicationServiceBase, IInterestCalculationAppService
    {
        private readonly IMediator _mediator;

        public InterestCalculationAppService(
           INotificationHandler notification,
           IMediator mediator)
           : base(notification)
        {
            _mediator = mediator;
        }

        public async Task<double> GetInterestCalculation(InterestCalculationCommand command)
        {
            var response = await _mediator.Send(command);

            if (Notification.HasNotification())
                return default;

            return response;
        }
    }
}
