using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Recipe.Dtos.Request;
using Recipe.Dtos.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Recipe.Bll.Services.TokenServices
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public GenerateTokenResponseDto GenerateToken(GenerateTokenRequestDto request)
        {
            try
            {
                SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]));

                var dateTimeNow = DateTime.UtcNow;

                JwtSecurityToken jwt = new JwtSecurityToken(
                        issuer: _configuration["JwtSettings:ValidIssuer"],
                        audience: _configuration["JwtSettings:ValidAudience"],
                        claims: new List<Claim> {
                    new Claim("UserName", request.UserName),
                    new Claim("Role", request.Role)
                        },
                        notBefore: dateTimeNow,
                        expires: dateTimeNow.Add(TimeSpan.FromMinutes(60)),
                        signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                    );

                return new GenerateTokenResponseDto
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                    TokenExpireDate = dateTimeNow.Add(TimeSpan.FromMinutes(60))
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Token Hatasi");
            }
        }
    }
}
