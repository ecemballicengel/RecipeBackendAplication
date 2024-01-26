namespace Recipe.Entities
{
    public class RecipeIngredientsEntity : BaseEntity
    {
        public string Name { get; set; } = "";
        public double Amount { get; set; }
        public int AmountTypeId { get; set; }
        public int RecipeId { get; set; }
    }
}
