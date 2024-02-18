using Microsoft.IdentityModel.Tokens;
using Recipe.Bll.Services.HelperServices;
using Recipe.Dal.DbContexts;
using Recipe.Dtos.Request;
using Recipe.Dtos.Response;
using Recipe.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Recipe.Bll.Services.RecipeServices
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeDbContext _dbContext;
        private readonly IHelperService _helperService;

        public RecipeService(RecipeDbContext dbContext, IHelperService helperService)
        {
            _dbContext = dbContext;
            _helperService = helperService;
        }
        public List<RecipeResponseDto> GetRecipeList()
        {
            try
            {
                var recipes = _dbContext.Recipes.Where(x => x.IsDeleted == false).ToList();

                var response = new List<RecipeResponseDto>();

                foreach (var recipe in recipes)
                {
                    var user = _dbContext.Users.FirstOrDefault(x => x.Id == recipe.CreatedBy);
                    
                    response.Add(new RecipeResponseDto
                    {
                        Id = recipe.Id,
                        CategoryId = recipe.CategoryId,
                        Title = recipe.Title,
                        TitleImage = recipe.TitleImage,
                        PreparetionTime = recipe.PreparetionTime,
                        NumberOfPeople = recipe.NumberOfPeople,
                        CookingTime = recipe.CookingTime,
                        UserName = user != null && user.UserName.IsNullOrEmpty() ? "" : user.UserName,
                        UserImage = user != null && user.ImageUrl.IsNullOrEmpty() ? "" : user.ImageUrl,
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
                if (response == null)
                {
                    return new RecipeResponseDto();
                }
                return new RecipeResponseDto
                {
                    Id = response.Id,
                    Title = response.Title,
                    TitleImage = response.TitleImage,
                    PreparetionTime = response.PreparetionTime,
                    CookingTime = response.CookingTime,
                    NumberOfPeople = response.NumberOfPeople,
                    CategoryId = response.CategoryId
                };

            }
            catch (Exception ex)
            {

                throw new Exception("Rastgele Yemek Getirilemedi");
            }
        }

        private int GenerateRandomCategoryId(int minNumber, int maxNumber)
        {
            Random rand = new Random();

            var randomNumber = rand.Next(minNumber, maxNumber);

            return randomNumber;
        }
        #endregion

        public int AddRecipe(AddRecipeRequestDto request)
        {
            try
            {
                var data = new RecipeEntity
                {
                    CreatedAt = DateTime.Now,
                    CategoryId = request.CategoryId,
                    CookingTime = request.CookingTime,
                    Title = request.Title,
                    TitleImage = request.TitleImage.IsNullOrEmpty() ? "" : _helperService.SaveImage(request.TitleImage),
                    PreparetionTime = request.PreparetionTime,
                    NumberOfPeople = request.NumberOfPeople,
                    IsDeleted = false,
                    CreatedBy = StaticValues.UserId
                };

                var recipes = _dbContext.Recipes.Add(data);
                _dbContext.SaveChanges();

                int recipeId = data.Id;
                return recipeId;
            }
            catch (Exception ex)
            {

                throw new Exception("Tarif eklenemedi");
            }
        }
        public void UpdateRecipe(UpdateRecipeRequestDto request)
        {
            try
            {
                var existingRecipe = _dbContext.Recipes.FirstOrDefault(x => x.IsDeleted == false && x.Id == request.Id);

                if (existingRecipe == null)
                {

                    throw new Exception("Tarif bulunamadı");
                }

                existingRecipe.Title = request.Title;
                existingRecipe.TitleImage = request.TitleImage.IsNullOrEmpty() ? "" : _helperService.SaveImage(request.TitleImage);
                existingRecipe.NumberOfPeople = request.NumberOfPeople;
                existingRecipe.CookingTime = request.CookingTime;
                existingRecipe.PreparetionTime = request.PreparetionTime;
                existingRecipe.CategoryId = request.CategoryId;
                existingRecipe.UpdatedAt = DateTime.Now;
                existingRecipe.UpdatedBy = StaticValues.UserId;

                _dbContext.Update(existingRecipe);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Tarif guncellenemedi");
            }
        }

        public void DeleteRecipe(DeleteRecipeRequestDto request)
        {
            try
            {
                var existingRecipe = _dbContext.Recipes.FirstOrDefault(r => r.Id == request.Id && r.IsDeleted == false);

                if (existingRecipe == null)
                {
                    throw new Exception("Tarif bulunamadi");
                }
                existingRecipe.IsDeleted = true;
                _dbContext.Update(existingRecipe);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Tarif bulunamadi");
            }
        }

        public RecipeByIdResponseDto GetRecipeById(GetRecipeByIdRequestDto request)
        {

            var data = _dbContext.Recipes.FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == data.CreatedBy);
            var response = new RecipeByIdResponseDto()
            {
                Id = data.Id,
                CategoryId = data.CategoryId,
                Title = data.Title,
                TitleImage = data.TitleImage,
                PreparetionTime = data.PreparetionTime,
                NumberOfPeople = data.NumberOfPeople,
                CookingTime = data.CookingTime,
                UserName = user != null && user.UserName.IsNullOrEmpty() ? "" : user.UserName,
                UserImage = user != null && user.ImageUrl.IsNullOrEmpty() ? "" : user.ImageUrl,

            };
            return response;


        }

        public List<RecipeResponseDto> GetRecipeListByUserId(GetRecipeListByUserIdRequestDto request)
        {
            try
            {
                var recipes = _dbContext.Recipes.Where(x => x.IsDeleted == false && request.UserId == x.CreatedBy).ToList();

                var response = new List<RecipeResponseDto>();

                foreach (var recipe in recipes)
                {
                    var user = _dbContext.Users.FirstOrDefault(x => x.Id == recipe.CreatedBy);

                    response.Add(new RecipeResponseDto
                    {
                        Id = recipe.Id,
                        CategoryId = recipe.CategoryId,
                        Title = recipe.Title,
                        TitleImage = recipe.TitleImage,
                        PreparetionTime = recipe.PreparetionTime,
                        NumberOfPeople = recipe.NumberOfPeople,
                        CookingTime = recipe.CookingTime,
                        UserName = user != null && user.UserName.IsNullOrEmpty() ? "" : user.UserName,
                        UserImage = user != null && user.ImageUrl.IsNullOrEmpty() ? "" : user.ImageUrl,
                    });
                }

                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Tarifleri getirirken bir hata olustu");
            }

        }
        public void UpdateUserRecipe(UpdateUserRecipeRequestDto request)
        {
            try
            {
                var existingRecipe = _dbContext.Recipes.FirstOrDefault(x => x.Id == request.RecipeId && x.IsDeleted == false && x.CreatedBy == request.UserId);

                if (existingRecipe == null)
                {
                    throw new Exception("Kullanıcıya ait tarif bulunamadı");
                }

                existingRecipe.Title = request.Title;
                existingRecipe.TitleImage = request.TitleImage.IsNullOrEmpty() ? "" : _helperService.SaveImage(request.TitleImage);
                existingRecipe.NumberOfPeople = request.NumberOfPeople;
                existingRecipe.CookingTime = request.CookingTime;
                existingRecipe.PreparetionTime = request.PreparetionTime;
                existingRecipe.CategoryId = request.CategoryId;
                existingRecipe.UpdatedAt = DateTime.Now;

                _dbContext.Update(existingRecipe);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Tarif güncellenirken bir hata oluştu");
            }
        }
        public void DeleteUserRecipe(DeleteUserRecipeRequestDto request)
        {
            try
            {
                var existingRecipe = _dbContext.Recipes.FirstOrDefault(x => x.Id == request.RecipeId && x.IsDeleted == false && x.CreatedBy == request.UserId);

                if (existingRecipe == null)
                {
                    throw new Exception("Kullanıcıya ait tarif bulunamadı");
                }

                existingRecipe.IsDeleted = true;
                _dbContext.Update(existingRecipe);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Tarif silinirken bir hata oluştu");
            }

        }

    }
}
