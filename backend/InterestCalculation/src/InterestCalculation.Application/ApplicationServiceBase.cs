using Tnf.Application.Services;
using Tnf.Notifications;

namespace InterestCalculation.Application
{
    public abstract class ApplicationServiceBase : ApplicationService
    {
        protected ApplicationServiceBase(INotificationHandler notification) : base(notification)
        {
        }
    }
}
