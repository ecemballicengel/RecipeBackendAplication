using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.CategoryServices
{
    public interface ICategoryService
    {
        List<CategoryResponseDto> GetCategortyList();
    }
}
