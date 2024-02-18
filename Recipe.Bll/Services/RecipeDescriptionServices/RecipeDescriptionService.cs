using Microsoft.IdentityModel.Tokens;
using Recipe.Bll.Services.HelperServices;
using Recipe.Dal.DbContexts;
using Recipe.Dtos.Request;
using Recipe.Dtos.Response;
using Recipe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Bll.Services.RecipeDescriptionServices
{
    public class RecipeDescriptionService : IRecipeDescriptionService
    {
        private readonly RecipeDbContext _dbContext;
        private readonly IHelperService _helperService;

        public RecipeDescriptionService(RecipeDbContext dbContext, IHelperService helperService)
        {
            _dbContext = dbContext;
            _helperService = helperService;
        }
        public List<RecipeDescriptionResponseDto> GetRecipeDescriptionsByRecipeId(GetRecipeDescriptionByRecipeIdRequestDto request)
        {
            try
            {
                var data = _dbContext.RecipeDescriptions
                    .Where(x => x.RecipeId == request.RecipeId && x.IsDeleted == false)
                    .Select(x => new RecipeDescriptionResponseDto
                    {
                        Id = x.Id,
                        Description = x.Description,
                        ImageUrl = x.ImageUrl,
                    })
                    .ToList();

                return data;
            }
            catch (Exception ex)
            {

                throw new Exception("Tarif aciklamasi getirilirken bir hata olustu");
            }
        }
        public void CreateRecipeDescription(List<CreateRecipeDescriptionRequestDto> request)
        {
            try
            {
                foreach (var recipeDescription in request)
                {

                    _dbContext.Add(new RecipeDescriptionEntity
                    {
                        Description = recipeDescription.Description,
                        ImageUrl = recipeDescription.ImageUrl.IsNullOrEmpty() ? "" : _helperService.SaveImage(recipeDescription.ImageUrl),
                        CreatedAt = DateTime.UtcNow,
                        IsDeleted = false,
                        RecipeId = recipeDescription.RecipeId,
                        CreatedBy = StaticValues.UserId,
                    });

                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Aciklama eklerken hata olustu");
            }
        }

        public void UpdateRecipeDescription(List<UpdateRecipeDescriptionRequestDto> request)
        {
            try
            {
                foreach (var recipeDescription in request)
                {
                    var data = _dbContext.RecipeDescriptions.FirstOrDefault(x => x.IsDeleted == false && x.Id == recipeDescription.Id);

                    if (data == null)
                    {
                        throw new Exception("Tarif Tanimi bulunamadi");
                    }

                    data.Description = recipeDescription.Description;
                    data.ImageUrl = recipeDescription.ImageUrl.IsNullOrEmpty() ? "" : _helperService.SaveImage(recipeDescription.ImageUrl);
                    data.RecipeId = recipeDescription.RecipeId;
                    data.UpdatedAt = DateTime.UtcNow;
                    data.UpdatedBy = StaticValues.UserId;
                    _dbContext.Update(data);
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Tarif tanimi guncellemede hata olustu");
            }
        }

        public void DeleteRecipeDescription(DeleteRecipeDescriptionRequestDto request)
        {
            try
            {
                var data = _dbContext.RecipeDescriptions.FirstOrDefault(x => x.Id == request.Id);

                if (data == null)
                {
                    throw new Exception("Tarif Tanimi bulunamadi");
                }

                data.IsDeleted = true;
                _dbContext.Update(data);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Tarif tanimi silinemedi");
            }
        }
    }
}
