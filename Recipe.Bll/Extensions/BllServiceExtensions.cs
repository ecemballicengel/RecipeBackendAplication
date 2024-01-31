using Microsoft.Extensions.DependencyInjection;
using Recipe.Bll.Services.CategoryServices;
using Recipe.Bll.Services.RecipeIngredientServices;
using Recipe.Bll.Services.RecipeServices;
using Recipe.Dal.Extensions;

namespace Recipe.Bll.Extensions
{
    public static class BllServiceExtensions
    {
        public static void AddBllServices(this IServiceCollection services)
        {
            services.AddDalServices();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();
        }
    }
}
