using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.AdminServices
{
    public interface IAdminService
    {
        List<UserResponseDto> GetAllUsers();
        void UpdateUser(UpdateUserRequestDto request);
        void DeleteUser(DeleteUserRequestDto request);

        List<RecipeResponseDto> GetAllRecipes();
        void AddRecipe(AddRecipeRequestDto request);
        void UpdateRecipe(UpdateRecipeRequestDto request);
        void DeleteRecipe(DeleteRecipeRequestDto request);

        List<CategoryResponseDto> GetAllCategories();
        void AddCategory(CreateCategoryRequestDto request);
        void UpdateCategory(UpdateCategoryRequestDto request);
        void DeleteCategory(DeleteCategoryRequestDto request);

    }
}
