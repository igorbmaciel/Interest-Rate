using System.Threading.Tasks;

namespace InterestRate.Client
{
    public interface IInterestRateClient
    {
        Task<double> GetInterestRate();
    }
}
