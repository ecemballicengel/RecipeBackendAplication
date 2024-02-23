using Recipe.Bll.Enums;
using Recipe.Bll.Services.RecipeServices;
using Recipe.Dal.DbContexts;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.SearchServices
{
    public class SearchService : ISearchService
    {
        private readonly RecipeDbContext _dbContext;
        private readonly IRecipeService _recipeService;

        public SearchService(RecipeDbContext dbContext, IRecipeService recipeService)
        {
            _dbContext = dbContext;
            _recipeService = recipeService;
        }

        public List<RecipeResponseDto> GetRecipesByCriteria(SearchCriteria search, string keyword)
        {
            var response = new List<RecipeResponseDto>();
            switch (search)
            {
                case SearchCriteria.RecipeTitle:
                    response = GetRecipesByTitle(keyword);
                    break;
                case SearchCriteria.RecipeDescription:
                    response = GetRecipesByRecipeDescriptions(keyword);
                    break;
                case SearchCriteria.Ingredients:
                    response = GetRecipesByIngredients(keyword);
                    break;
            }

            return response;
        }

        private List<RecipeResponseDto> GetRecipesByTitle(string keyword) =>
            _recipeService.GetRecipeList().Where(x => x.Title.ToLower().Contains(keyword.ToLower())).ToList();


        private List<RecipeResponseDto> GetRecipesByRecipeDescriptions(string keyword)
        {
            var descriptions = _dbContext.RecipeDescriptions
                .Where(x => x.IsDeleted == false && x.Description.ToLower().Contains(keyword.ToLower()))
                .ToList();

            var recipeIdList = new List<int>();

            foreach (var description in descriptions)
            {
                recipeIdList.Add(description.RecipeId);
            }

            return _recipeService.GetRecipeList().Where(x => recipeIdList.Contains(x.Id)).ToList();
        }

        private List<RecipeResponseDto> GetRecipesByIngredients(string keyword)
        {
            var ingredients = _dbContext.RecipeIngredients
                .Where(x => x.IsDeleted == false && x.Name.ToLower().Contains(keyword.ToLower()))
                .ToList();

            var recipeIdList = new List<int>();

            ingredients.ForEach(x => recipeIdList.Add(x.RecipeId));

            return _recipeService.GetRecipeList().Where(x => recipeIdList.Contains(x.Id)).ToList();

        }

        public List<RecipeResponseDto> GetRecipesByCategory(int id)
        => _recipeService.GetRecipeList().Where(x => x.CategoryId == id).ToList();




    }
}
