using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Bll.Services.UserServices;
using Recipe.Dtos.Request;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("UpdateUserProfile")]
        public IActionResult UpdateUserProfile(UpdateUserProfileRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Geçersiz veri");
            }

            try
            {
                _userService.UpdateUserProfile(request);
                return Ok("Kullanıcı profili güncellendi");
            }
            catch (Exception ex)
            {
                return BadRequest("Kullanıcı profili güncellenirken bir hata oluştu");
            }
        }
        [HttpPut("UpdateUserPassword")]
        public IActionResult UpdateUserPassword(UpdateUserPasswordRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Geçersiz veri");
            }

            try
            {
                _userService.UpdateUserPassword(request);
                return Ok("Şifre güncellendi");
            }
            catch (Exception ex)
            {
                return BadRequest("Şifre güncellenirken bir hata oluştu");
            }
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(new GetUserByIdRequestDto { UserId=id});
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Kullanıcı getirilirken bir hata oluştu");
            }
        }
    }
}
