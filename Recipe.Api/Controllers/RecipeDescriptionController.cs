using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Bll.Services.RecipeDescriptionServices;
using Recipe.Dtos.Request;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RecipeDescriptionController : ControllerBase
    {
        private readonly IRecipeDescriptionService _recipeDescriptionService;

        public RecipeDescriptionController(IRecipeDescriptionService recipeDescriptionService)
        {
            _recipeDescriptionService = recipeDescriptionService;
        }

        [AllowAnonymous]
        [HttpGet("{recipeId}")]
        public IActionResult GetRecipeIngredients(int recipeId)
        {
            var data = _recipeDescriptionService.GetRecipeDescriptionsByRecipeId(new GetRecipeDescriptionByRecipeIdRequestDto { RecipeId = recipeId });
            return Ok(data);
        }
        [HttpPost]
        public IActionResult CreateRecipeDescription(List<CreateRecipeDescriptionRequestDto> request)
        {
            _recipeDescriptionService.CreateRecipeDescription(request);
            return Ok("Aciklama eklendi");
        }

        [HttpPut]
        public IActionResult UpdateRecipeDescription(List<UpdateRecipeDescriptionRequestDto> request)
        {
            _recipeDescriptionService.UpdateRecipeDescription(request);
            return Ok("Tarif Tanimi Guncelleme Basarili");
        }

        [HttpDelete]
        public IActionResult DeleteRecipeDescription(DeleteRecipeDescriptionRequestDto request)
        {
            _recipeDescriptionService.DeleteRecipeDescription(request);
            return Ok("Silme Islemi Basarili");
        }
    }
}
