namespace Recipe.Entities
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public string AuthToken { get; set; } = "";
        public DateTime AccessTokenExpireDate { get; set; }
        public string Role { get; set; } = "";
        public int RetryCount { get; set; }
    }
}
