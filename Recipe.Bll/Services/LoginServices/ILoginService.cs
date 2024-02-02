using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.LoginServices
{
    public interface ILoginService
    {
        LoginResponseDto Login(LoginRequestDto request);
    }
}
