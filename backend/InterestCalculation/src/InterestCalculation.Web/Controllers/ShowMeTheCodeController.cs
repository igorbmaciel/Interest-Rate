using InterestCalculation.Application.Interfaces;
using InterestCalculation.Web.Route;
using Microsoft.AspNetCore.Mvc;

namespace InterestCalculation.Web.Controllers
{
    [Route(RouteConsts.ShowMeTheCode)]
    public class ShowMeTheCodeController : InterestCalculationBaseController
    {
        private readonly IShowMeTheCodeAppService _showMeTheCodeAppService;

        public ShowMeTheCodeController(IShowMeTheCodeAppService showMeTheCodeAppService)
        {
            _showMeTheCodeAppService = showMeTheCodeAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            var response = _showMeTheCodeAppService.Code();
            return CreateResponseOnGet(response, RouteResponseConsts.InterestCalculation);
        }
    }
}
