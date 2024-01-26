namespace Recipe.Entities
{
    public class RecipeDescriptionEntity : BaseEntity
    {
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int RecipeId { get; set; }
    }
}
