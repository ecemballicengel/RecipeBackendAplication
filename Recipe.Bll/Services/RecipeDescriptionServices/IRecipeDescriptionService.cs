using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.RecipeDescriptionServices
{
    public interface IRecipeDescriptionService
    {
        List<RecipeDescriptionResponseDto> GetRecipeDescriptionsByRecipeId(GetRecipeDescriptionByRecipeIdRequestDto request);
        void CreateRecipeDescription(List<CreateRecipeDescriptionRequestDto> request);
        void UpdateRecipeDescription(List<UpdateRecipeDescriptionRequestDto> request);
        void DeleteRecipeDescription(DeleteRecipeDescriptionRequestDto request);

    }
}
