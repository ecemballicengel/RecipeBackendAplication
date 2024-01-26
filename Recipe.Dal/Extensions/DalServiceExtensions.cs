using Microsoft.Extensions.DependencyInjection;
using Recipe.Dal.DbContexts;

namespace Recipe.Dal.Extensions
{
    public static class DalServiceExtensions
    {
        public static void AddDalServices(this IServiceCollection services)
        {
            services.AddDbContext<RecipeDbContext>();
        }
    }
}
