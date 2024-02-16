namespace Recipe.Dtos.Request
{
    public class UpdateUserPasswordRequestDto
    {
        public int UserId { get; set; }
        public string Password { get; set; } = "";
    }
}
