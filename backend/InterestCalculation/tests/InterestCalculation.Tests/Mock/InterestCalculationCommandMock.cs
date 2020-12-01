using InterestCalculation.Domain.Queries.Request;

namespace InterestCalculation.Tests.Mock
{
    public class InterestCalculationCommandMock
    {
        public static InterestCalculationCommand GetValidDto()
        {
            return new InterestCalculationCommand()
            {
                 InitialValue = 100,
                 Month = 5
            };
        }

        public static InterestCalculationCommand GetAnotherValidDto()
        {
            return new InterestCalculationCommand()
            {
                InitialValue = 150,
                Month = 10
            };
        }

        public static InterestCalculationCommand GetDifferentValidDto()
        {
            return new InterestCalculationCommand()
            {
                InitialValue = 75,
                Month = 3
            };
        }

        public static InterestCalculationCommand GetInvalidDto()
        {
            return new InterestCalculationCommand()
            {
                InitialValue = default,
                Month = default
            };
        }
    }
}
