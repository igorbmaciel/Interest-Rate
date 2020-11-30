using InterestRate.Application.Interfaces;

namespace InterestRate.Application.Services
{
    public class InterestRateAppService : IInterestRateAppService
    {
        public double GetInterestRate()
        {
            const double interestRate = 0.01;
            return interestRate;
        }
    }
}
