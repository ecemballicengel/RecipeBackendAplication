using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Recipe.Bll.Enums;
using Recipe.Bll.Services.RecipeServices;
using Recipe.Bll.Services.SearchServices;
using Recipe.Dtos.Request;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly ISearchService _searchService;

        public RecipeController(IRecipeService recipeService,ISearchService searchService)
        {
            _recipeService = recipeService;
            _searchService = searchService;
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

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetRecipeById(int id)
        {
            var data = _recipeService.GetRecipeById(new GetRecipeByIdRequestDto { Id = id });
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpGet("UserId/{id}")]
        public IActionResult GetRecipeByUserId(int id)
        {
            var data = _recipeService.GetRecipeListByUserId(new GetRecipeListByUserIdRequestDto { UserId = id });
            return Ok(data);
        }

        [HttpPut("UpdateUserRecipe")]
        public IActionResult UpdateUserRecipe(UpdateUserRecipeRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Geçersiz veri");
            }

            try
            {
                _recipeService.UpdateUserRecipe(request);
                return Ok("Tarif güncellendi");
            }
            catch (Exception ex)
            {
                return BadRequest("Tarif güncellenirken bir hata oluştu");
            }
        }
        [HttpDelete("DeleteUserRecipe")]
        public IActionResult DeleteUserRecipe(DeleteUserRecipeRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Geçersiz veri");
            }

            try
            {
                _recipeService.DeleteUserRecipe(request);
                return Ok("Tarif silindi");
            }
            catch (Exception ex)
            {
                return BadRequest("Tarif silinirken bir hata oluştu");
            }
        }

        [AllowAnonymous]
        [HttpGet("Search")]
        public IActionResult SearchRecipes([FromQuery] SearchCriteria criteria,string keyword)
        {
            var data = _searchService.GetRecipesByCriteria(criteria,keyword);

            return Ok(data);
        }

        [AllowAnonymous]
        [HttpGet("category/{id}")]
        public IActionResult SearchRecipes(int id)
        {
            var data = _searchService.GetRecipesByCategory(id);

            return Ok(data);
        }
    }
}
