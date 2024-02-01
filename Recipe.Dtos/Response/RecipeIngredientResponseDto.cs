namespace Recipe.Dtos.Response
{
    public class RecipeIngredientResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public double Amount { get; set; }
        public int AmountTypeId { get; set; }
    }
}
