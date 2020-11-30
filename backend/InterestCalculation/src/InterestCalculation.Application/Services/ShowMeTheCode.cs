using InterestCalculation.Application.Interfaces;

namespace InterestCalculation.Application.Services
{
    public class ShowMeTheCode : IShowMeTheCodeAppService
    {
        public string Code()
        {
            const string code = "https://github.com/igorbmaciel/Interest-Rate";
            return code;
        }
    }
}
