namespace Recipe.Entities
{
    public class CommentEntity : BaseEntity
    {
        public string Comment { get; set; } = "";
        public int RecipeId { get; set; }
    }
}
