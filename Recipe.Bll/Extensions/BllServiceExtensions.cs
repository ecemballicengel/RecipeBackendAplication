using Microsoft.Extensions.DependencyInjection;
using Recipe.Bll.Services.AmountTypeServices;
using Recipe.Bll.Services.CategoryServices;
using Recipe.Bll.Services.LoginServices;
using Recipe.Bll.Services.RecipeDescriptionServices;
using Recipe.Bll.Services.RecipeIngredientServices;
using Recipe.Bll.Services.RecipeServices;
using Recipe.Bll.Services.RegisterServices;
using Recipe.Bll.Services.TokenServices;
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
            services.AddScoped<IAmountTypeService, AmountTypeService>();
            services.AddScoped<IRecipeDescriptionService, RecipeDescriptionService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegisterService, RegisterService>();
        }
    }
}
