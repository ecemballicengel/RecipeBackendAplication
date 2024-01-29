using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Bll.Services.RecipeServices;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        [HttpGet]
        public IActionResult GetRecipeList() 
        {
            var recipeList= _recipeService.GetRecipeList();

            return Ok(recipeList);
        }

        [HttpGet("GetDailyMenu")]
        public IActionResult GetDailyRecipeList() 
        {
            var recipeList = _recipeService.GetDailyRecipeList();
            return Ok(recipeList);
        }
    }
}
