using Recipe.Bll.Services.RecipeBusinnessWorkFlowServices;
using Microsoft.AspNetCore.Mvc;
using Recipe.Dtos.Request;
using Microsoft.AspNetCore.Authorization;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeBusinnessWorkFlowController : ControllerBase
    {
        private readonly IRecipeBusinessWorkFlowService _recipeBusinnessWorkFlow;

        public RecipeBusinnessWorkFlowController(IRecipeBusinessWorkFlowService recipeBusinnessWorkFlow)
        {
            _recipeBusinnessWorkFlow = recipeBusinnessWorkFlow;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateRecipeBusinessWorkFlow(CreateRecipeBusinessWorkFlow request)
        {
            _recipeBusinnessWorkFlow.CreateRecipeBusinessWorkFlow(request);
            return Ok("Ekleme basarili");
        }
    }
}
