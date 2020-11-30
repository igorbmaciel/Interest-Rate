using InterestRate.Application.Interfaces;
using InterestRate.Web.Base;
using InterestRate.Web.Route;
using Microsoft.AspNetCore.Mvc;

namespace InterestRate.Web.Controllers
{
    [Route(RouteConsts.InterestRate)]
    public class InterestRateController : BaseController
    {
        private readonly IInterestRateAppService _interestRateAppService;

        public InterestRateController(IInterestRateAppService interestRateAppService)
        {
            _interestRateAppService = interestRateAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(double), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            var response = _interestRateAppService.GetInterestRate();

            return CreateResponseOnGet(response, RouteResponseConsts.InterestRate);
        }
    }
}
