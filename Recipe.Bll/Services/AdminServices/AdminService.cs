using Microsoft.IdentityModel.Tokens;
using Recipe.Bll.Services.CategoryServices;
using Recipe.Bll.Services.HelperServices;
using Recipe.Bll.Services.RecipeServices;
using Recipe.Dal.DbContexts;
using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly RecipeDbContext _dbContext;
        private readonly IHelperService _helperService;
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;


        public AdminService(RecipeDbContext dbContext, IHelperService helperService, IRecipeService recipeService,
        ICategoryService categoryService)
        {
            _dbContext = dbContext;
            _helperService = helperService;
            _recipeService = recipeService;
            _categoryService = categoryService;
        }

        public List<UserResponseDto> GetAllUsers()
        {
            var users = _dbContext.Users
               .Where(u => !u.IsDeleted)
               .Select(u => new UserResponseDto
               {
                   UserId = u.Id,
                   UserName = u.UserName,
                   Email = u.Email,
                   ImageUrl = u.ImageUrl,
                   Role = u.Role,
                   RecipeCount = _dbContext.Recipes.Count(r => r.CreatedBy == u.Id)
               })
               .ToList();

            return users;
        }
        public void DeleteUser(DeleteUserRequestDto request)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == request.UserId && !u.IsDeleted);

            if (existingUser == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            existingUser.IsDeleted = true;
            _dbContext.Update(existingUser);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(UpdateUserRequestDto request)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == request.UserId && !u.IsDeleted);

            if (existingUser == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            existingUser.UserName = request.UserName;
            existingUser.Email = request.Email;
            existingUser.Role = request.Role;
            existingUser.ImageUrl = _helperService.SaveImage(request.ImageUrl);
            existingUser.UpdatedAt = DateTime.Now;

            _dbContext.Update(existingUser);
            _dbContext.SaveChanges();
        }

        public List<RecipeResponseDto> GetAllRecipes()
        {
            return _recipeService.GetRecipeList();
        }

        public void AddRecipe(AddRecipeRequestDto request)
        {
            _recipeService.AddRecipe(request);
        }

        public void UpdateRecipe(UpdateRecipeRequestDto request)
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

            _dbContext.Update(existingRecipe);
            _dbContext.SaveChanges();
        }

        public void DeleteRecipe(DeleteRecipeRequestDto request)
        {
            _recipeService.DeleteRecipe(request);
        }

        public List<CategoryResponseDto> GetAllCategories()
        {
            return _categoryService.GetCategortyList();
        }

        public void AddCategory(CreateCategoryRequestDto request)
        {
            _categoryService.CreateCategory(request);
        }

        public void UpdateCategory(UpdateCategoryRequestDto request)
        {
            _categoryService.UpdateCategory(request);
        }

        public void DeleteCategory(DeleteCategoryRequestDto request)
        {
            _categoryService.DeleteCategory(request);
        }
    }
}
