using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.Bll;
using Recipe.Bll.Services.LoginServices;
using Recipe.Dtos.Request;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public IActionResult Login(LoginRequestDto request)
        {
            var data = _loginService.Login(request);
            StaticValues.UserId = data.UserId;
            return Ok(data);
        }
    }
}
