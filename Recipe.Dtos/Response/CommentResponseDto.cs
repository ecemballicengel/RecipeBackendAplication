namespace Recipe.Dtos.Response
{
    public class CommentResponseDto
    {
        public int Id { get; set; }
        public string Comment { get; set; } = "";
        public int RecipeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; } = "";
        public string UserImage { get; set; } = "";
        public int UserId { get; set; }
    }
}
