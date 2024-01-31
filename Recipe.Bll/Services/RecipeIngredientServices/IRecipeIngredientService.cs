using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.RecipeIngredientServices
{
    public interface IRecipeIngredientService
    {
        List<RecipeIngredientResponseDto> GetRecipeIngredientsByRecipeId(GetRecipeIngredientsByRecipeIdRequestDto request);
        void CreateRecipeIngredient(List<CreateRecipeIngredientRequestDto> request);
        void UpdateRecipeIngredient(List<UpdateRecipeIngredientRequestDto> request);
        void DeleteRecipeIngredient(DeleteRecipeIngredientRequestDto request);
    }
}
