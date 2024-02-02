using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Bll.Services.RecipeIngredientServices;
using Recipe.Dtos.Request;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        private readonly IRecipeIngredientService _recipeIngredientService;

        public RecipeIngredientController(IRecipeIngredientService recipeIngredientService)
        {
            _recipeIngredientService = recipeIngredientService;
        }

        [HttpPost]
        public IActionResult CreateRecipeIngredient(List<CreateRecipeIngredientRequestDto> request)
        {
            _recipeIngredientService.CreateRecipeIngredient(request);
            return Ok("Malzemeler eklendi");
        }

        [HttpPut]
        public IActionResult UpdateRecipeIngredient(List<UpdateRecipeIngredientRequestDto> request)
        {
            _recipeIngredientService.UpdateRecipeIngredient(request);
            return Ok("Malzemeler guncellendi");
        }

        [HttpDelete]
        public IActionResult DeleteRecipeIngredient(DeleteRecipeIngredientRequestDto request)
        {
            _recipeIngredientService.DeleteRecipeIngredient(request);
            return Ok("Malzeme silme basarili");
        }
        [AllowAnonymous]
        [HttpGet("{recipeId}")]
        public IActionResult GetRecipeIngredients(int recipeId)
        {
            var data = _recipeIngredientService.GetRecipeIngredientsByRecipeId( new GetRecipeIngredientsByRecipeIdRequestDto { RecipeId = recipeId});
            return Ok(data);
        }
    }
}
