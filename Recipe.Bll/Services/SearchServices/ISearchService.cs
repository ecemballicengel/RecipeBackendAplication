using Recipe.Bll.Enums;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.SearchServices
{
    public interface ISearchService
    {
        List<RecipeResponseDto> GetRecipesByCategory(int id);
        List<RecipeResponseDto> GetRecipesByCriteria(SearchCriteria search, string keyword);
    }
}