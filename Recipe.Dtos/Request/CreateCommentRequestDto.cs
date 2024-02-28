namespace Recipe.Dtos.Request
{
    public class CreateCommentRequestDto
    {
        public string Comment { get; set; } = "";
        public int RecipeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }

    }
}
