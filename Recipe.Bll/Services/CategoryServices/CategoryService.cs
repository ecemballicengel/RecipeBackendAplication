using Recipe.Dal.DbContexts;
using Recipe.Dtos.Request;
using Recipe.Dtos.Response;
using Recipe.Entities;

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

        public void CreateCategory(CreateCategoryRequestDto request)
        {
            try
            {
                var data = _dbContext.Categories.Add(new CategoriesEntity
                {
                    Name = request.Name,
                    Description= request.Description,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Kategori eklenemedi");
            }
        }
        public void UpdateCategory(UpdateCategoryRequestDto request)
        {
            try
            {
                var data = _dbContext.Categories.FirstOrDefault(x => x.IsDeleted == false && x.Id == request.Id);
                if (data == null)
                {

                    throw new Exception("Kategori bulunamadı");
                }
                data.Name = request.Name;
                data.Description = request.Description;
                data.UpdatedAt = DateTime.UtcNow;
                _dbContext.Update(data);
                _dbContext.SaveChanges(true);
            }
            catch (Exception ex)
            {

                throw new Exception("Kategori guncellenemedi");
            }
        }
        public void DeleteCategory(DeleteCategoryRequestDto request)
        {

            try
            {
                var data = _dbContext.Categories.FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);

                if (data == null)
                {
                    throw new Exception("Kategori bulunamadi");
                }
                data.IsDeleted = true;
                _dbContext.Update(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Kategori bulunamadi");
            }
        }
    }
}
