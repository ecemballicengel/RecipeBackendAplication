namespace Recipe.Dtos.Request
{
    public class UpdateUserRecipeRequestDto
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public string Title { get; set; } = "";
        public string TitleImage { get; set; } = "";
        public int NumberOfPeople { get; set; }
        public int PreparetionTime { get; set; }
        public int CookingTime { get; set; }
        public int CategoryId { get; set; }
    }
}
