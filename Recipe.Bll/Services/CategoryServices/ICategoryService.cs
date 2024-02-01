using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.CategoryServices
{
    public interface ICategoryService
    {
        List<CategoryResponseDto> GetCategortyList();
        void CreateCategory(CreateCategoryRequestDto request);
        void UpdateCategory(UpdateCategoryRequestDto request);
        void DeleteCategory(DeleteCategoryRequestDto request);
    }
}
