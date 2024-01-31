using Recipe.Dal.DbContexts;
using Recipe.Dtos.Request;
using Recipe.Dtos.Response;
using Recipe.Entities;

namespace Recipe.Bll.Services.RecipeIngredientServices
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly RecipeDbContext _dbContext;

        public RecipeIngredientService(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<RecipeIngredientResponseDto> GetRecipeIngredientsByRecipeId(GetRecipeIngredientsByRecipeIdRequestDto request)
        {
            try
            {
                var data = _dbContext.RecipeIngredients
                    .Where(x => x.RecipeId == request.RecipeId)                 
                    .Select(x => new RecipeIngredientResponseDto
                    {
                        Amount = x.Amount,
                        AmountTypeId = x.AmountTypeId,
                        Name = x.Name
                    })
                    .ToList();

                return data;
            }
            catch (Exception ex)
            {

                throw new Exception("Tarif malzemeleri getirilirken bir hata olustu");
            }
        }

        public void CreateRecipeIngredient(List<CreateRecipeIngredientRequestDto> request)
        {
            try
            {
                foreach (var recipeIngredient in request)
                {

                    _dbContext.Add(new RecipeIngredientsEntity
                    {
                        Amount = recipeIngredient.Amount,
                        AmountTypeId = recipeIngredient.AmountTypeId,
                        CreatedAt = DateTime.UtcNow,
                        Name = recipeIngredient.Name,
                        IsDeleted = false,
                        RecipeId = recipeIngredient.RecipeId
                    });

                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Malzeme eklerken hata olustu");
            }
        }

        public void UpdateRecipeIngredient(List<UpdateRecipeIngredientRequestDto> request)
        {

            foreach (var ingredient in request)
            {
                var data = _dbContext.RecipeIngredients.FirstOrDefault(x => x.Id == ingredient.Id && x.IsDeleted == false);
                
                if(data == null)
                {
                    throw new Exception("Malzeme kaydi bulunamadi");
                }

                data.Amount = ingredient.Amount;
                data.AmountTypeId = ingredient.AmountTypeId;
                data.Name = ingredient.Name;
                data.RecipeId = ingredient.RecipeId;
                data.UpdatedAt = DateTime.UtcNow;

                _dbContext.Update(data);
            }
            
            _dbContext.SaveChanges();
        }

        public void DeleteRecipeIngredient(DeleteRecipeIngredientRequestDto request)
        {
            try
            {
                var data = _dbContext.RecipeIngredients.FirstOrDefault(x => x.IsDeleted == false && x.Id == request.Id);

                if(data == null)
                {
                    throw new Exception("Veri bulunamadi");
                }

                data.IsDeleted = true;
                _dbContext.Update(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Malzeme silmede hata olustu");
            }
        }
    }
}
