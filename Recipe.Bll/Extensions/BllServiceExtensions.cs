using Microsoft.Extensions.DependencyInjection;
using Recipe.Dal.Extensions;

namespace Recipe.Bll.Extensions
{
    public static class BllServiceExtensions
    {
        public static void AddBllServices(this IServiceCollection services)
        {
            services.AddDalServices();
        }
    }
}
