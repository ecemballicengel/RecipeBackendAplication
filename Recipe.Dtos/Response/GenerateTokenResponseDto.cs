namespace Recipe.Dtos.Response
{
    public class GenerateTokenResponseDto
    {
        public string Token { get; set; } = "";
        public DateTime TokenExpireDate { get; set; }
    }
}
