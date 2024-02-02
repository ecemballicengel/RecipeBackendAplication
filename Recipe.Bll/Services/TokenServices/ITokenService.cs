using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.TokenServices
{
    public interface ITokenService
    {
        GenerateTokenResponseDto GenerateToken(GenerateTokenRequestDto request);
    }
}
