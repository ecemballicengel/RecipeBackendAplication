using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.RecipeServices
{
    public interface IRecipeService
    {
        List<RecipeResponseDto> GetRecipeList();
        List<RecipeResponseDto> GetDailyRecipeList();

        int AddRecipe(AddRecipeRequestDto request);
        void UpdateRecipe(UpdateRecipeRequestDto request);
        void DeleteRecipe(DeleteRecipeRequestDto request);
    }
}
