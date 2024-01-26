using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Recipe.Dal.Extensions;
using Recipe.Entities;

namespace Recipe.Dal.DbContexts
{
    public class RecipeDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public RecipeDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Recipe_Db_Connection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedDataExtension.SeedCategories(modelBuilder);
            SeedDataExtension.SeedAmountTypes(modelBuilder);

        }

        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<RecipeDescriptionEntity> RecipeDescriptions { get; set; }
        public DbSet<RecipeIngredientsEntity> RecipeIngredients { get; set; }
        public DbSet<CategoriesEntity> Categories { get; set; }
        public DbSet<AmountTypesEntity> AmountTypes { get; set; }

    }
}
