using InterestCalculation.Domain.Queries.Request;
using System.Threading.Tasks;

namespace InterestCalculation.Application.Interfaces
{
    public interface IInterestCalculationAppService
    {
        Task<double> GetInterestCalculation(InterestCalculationCommand command);
    }
}
