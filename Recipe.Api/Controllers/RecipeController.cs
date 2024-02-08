using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Recipe.Bll.Services.RecipeServices;
using Recipe.Dtos.Request;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetRecipeList()
        {
            var recipeList = _recipeService.GetRecipeList();

            return Ok(recipeList);
        }

        [AllowAnonymous]
        [HttpGet("GetDailyMenu")]
        public IActionResult GetDailyRecipeList()
        {
            var recipeList = _recipeService.GetDailyRecipeList();
            return Ok(recipeList);
        }

        [HttpPost]
        public IActionResult AddRecipe(AddRecipeRequestDto request)
        {
            _recipeService.AddRecipe(request);
            return Ok("Ekleme basarili");
        }

        [HttpPut]
        public IActionResult UpdateRecipe(UpdateRecipeRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Gecersiz veri");
            }
            try
            {
                _recipeService.UpdateRecipe(request);
                return Ok("Tarif guncellendi");
            }
            catch (Exception ex)
            {

                throw new Exception("Guncelleme islemi basarisiz");
            }
        }
        [HttpDelete]
        public IActionResult DeleteRecipe(DeleteRecipeRequestDto request) 
        { 
            _recipeService.DeleteRecipe(request);
            return Ok("Tarif Silindi");
        }
    }
}
