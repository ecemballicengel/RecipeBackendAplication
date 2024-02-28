namespace Recipe.Dtos.Request
{
    public class UpdateCommentRequestDto
    {
        public int Id { get; set; }
        public string Comment { get; set; } = "";
        public int RecipeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
    }
}
