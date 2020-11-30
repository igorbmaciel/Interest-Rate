using InterestCalculation.Application.Interfaces;
using InterestCalculation.Domain.Queries.Request;
using InterestCalculation.Web.Controllers;
using InterestCalculation.Web.Route;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tnf.AspNetCore.Mvc.Response;

namespace InterestCalculation.Web.Base
{
    [Route(RouteConsts.InterestCalculation)]
    public class InterestCalculationController : InterestCalculationBaseController
    {
        private readonly IInterestCalculationAppService _interestCalculationAppService;

        public InterestCalculationController(IInterestCalculationAppService interestCalculationAppService)
        {
            _interestCalculationAppService = interestCalculationAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(decimal), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(InterestCalculationCommand command)
        {
            var response = await _interestCalculationAppService.GetInterestCalculation(command);
            return CreateResponseOnGet(response, RouteResponseConsts.InterestCalculation);
        }
    }
}
