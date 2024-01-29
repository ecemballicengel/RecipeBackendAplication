using Recipe.Dal.DbContexts;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly RecipeDbContext _dbContext;

        public CategoryService(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CategoryResponseDto> GetCategortyList()
        {
            try
            {
                var categories = _dbContext.Categories.Where(x=>x.IsDeleted == false).ToList();

                var response = new List<CategoryResponseDto>();
                
                foreach (var category in categories)
                {
                    response.Add(new CategoryResponseDto
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Description = category.Description
                    });
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Kategorileri getirirken bir hata olustu");
            }
        }
    }
}
