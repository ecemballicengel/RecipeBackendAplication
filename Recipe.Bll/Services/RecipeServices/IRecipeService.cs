using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.RecipeServices
{
    public interface IRecipeService
    {
        List<RecipeResponseDto> GetRecipeList();
        List<RecipeResponseDto> GetDailyRecipeList();
    }
}
