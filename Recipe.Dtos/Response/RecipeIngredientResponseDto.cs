namespace Recipe.Dtos.Response
{
    public class RecipeIngredientResponseDto
    {
        public string Name { get; set; } = "";
        public double Amount { get; set; }
        public int AmountTypeId { get; set; }
    }
}
