
namespace Recipe.Dtos.Request
{
    public class CreateRecipeIngredientRequestDto
    {
        public string Name { get; set; } = "";
        public double Amount { get; set; }
        public int AmountTypeId { get; set; }
        public int RecipeId { get; set; }
    }
}
