﻿namespace Recipe.Dtos.Response
{
    public class LoginResponseDto
    {
        public bool AuthenticateResult { get; set; }
        public string AuthToken { get; set; } = "";
        public DateTime AccessTokenExpireDate { get; set; }
    }
}
