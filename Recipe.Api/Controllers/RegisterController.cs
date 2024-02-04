using Microsoft.AspNetCore.Mvc;
using Recipe.Bll.Services.RegisterServices;
using Recipe.Dtos.Request;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        [HttpPost]
        public IActionResult RegisterUser(RegisterRequestDto request)
        {
            _registerService.RegisterUser(request);
            return Ok("Kullanici kaydi basarili");
        }
    }
}
