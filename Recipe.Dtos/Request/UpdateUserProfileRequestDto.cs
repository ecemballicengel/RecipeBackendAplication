namespace Recipe.Dtos.Request
{
    public class UpdateUserProfileRequestDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }
}
