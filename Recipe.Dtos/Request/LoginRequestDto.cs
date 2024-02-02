namespace Recipe.Dtos.Request
{
    public class LoginRequestDto
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
