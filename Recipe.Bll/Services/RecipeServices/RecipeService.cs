using Recipe.Dal.DbContexts;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.RecipeServices
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeDbContext _dbContext;

        public RecipeService(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<RecipeResponseDto> GetRecipeList()
        {
            try
            {
                var recipes = _dbContext.Recipes.Where(x => x.IsDeleted == false).ToList();

                var response = new List<RecipeResponseDto>();

                foreach (var recipe in recipes)
                {
                    response.Add(new RecipeResponseDto
                    {
                        Id = recipe.Id,
                        Title = recipe.Title,
                        TitleImage = recipe.TitleImage,
                        PreparetionTime = recipe.PreparetionTime,
                    });
                }

                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Tarifleri getirirken bir hata olustu");
            }
        }

        #region Daily Recipes
        public List<RecipeResponseDto> GetDailyRecipeList()
        {
            try
            {
                var soap = GetRandomRecipe(2);
                var meal = GetRandomRecipe(GenerateRandomCategoryId(5, 5));
                var salad = GetRandomRecipe(7);
                var desert = GetRandomRecipe(1);

                var response = new List<RecipeResponseDto>() { soap, meal, salad, desert };

                return response;

            }
            catch (Exception ex)
            {

                throw new Exception("Gunun Menusu Getirilirken Hata Olustu");
            }
        }


        private RecipeResponseDto GetRandomRecipe(int categoryId)
        {
            try
            {
                var recipes = _dbContext.Recipes.Where(x => x.CategoryId == categoryId && x.IsDeleted == false).OrderBy(x => Guid.NewGuid()).ToList();

                var response = recipes.FirstOrDefault();

                return new RecipeResponseDto
                {
                    Id =response.Id,
                    Title = response.Title,
                    TitleImage = response.TitleImage,
                    PreparetionTime= response.PreparetionTime,
                };

            }
            catch (Exception ex)
            {

                throw new Exception("Rastgele Yemek Getirilemedi");
            }
        }

        private int GenerateRandomCategoryId(int minNumber,int maxNumber)
        {
            Random rand = new Random();

            var randomNumber = rand.Next(minNumber, maxNumber);

            return randomNumber;
        }
        #endregion
    }
}
