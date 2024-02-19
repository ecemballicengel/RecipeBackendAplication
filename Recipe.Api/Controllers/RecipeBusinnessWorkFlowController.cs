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
        [HttpPut]
        [AllowAnonymous]
        public IActionResult UpdateRecipeBusinessWorkFlow(UpdateRecipeBusinessWorkFlowRequestDto request)
        {
            _recipeBusinnessWorkFlow.UpdateRecipeBusinessWorkFlow(request);
            return Ok("Guncelleme basarili");
        }
        [HttpDelete]
        [AllowAnonymous]
        public IActionResult DeleteRecipeBusinessWorkFlow(DeleteRecipeBusinessWorkFlowRequestDto request)
        {
            _recipeBusinnessWorkFlow.DeleteRecipeBusinessWorkFlow(request);
            return Ok("Silme basarili");
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetRecipeBussinessWorkFlow(int id)
        {
           var data = _recipeBusinnessWorkFlow.GetRecipeBussinessWorkFlow(new GetRecipeBusinessWorkFlowRequestDto { RecipeId = id});
            return Ok(data);
        }
    }
}
