using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Bll.Services.AdminServices;
using Recipe.Bll.Services.UserServices;
using Recipe.Dtos.Request;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;

        public AdminController(IAdminService adminService,IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }

        [HttpGet("Users")]
        public IActionResult GetAllUsers()
        {
            var users = _adminService.GetAllUsers();
            return Ok(users);
        }

        [HttpPut("Users")]
        public IActionResult UpdateUser(UpdateUserRequestDto request)
        {
            try
            {
                _adminService.UpdateUser(request);
                return Ok("Kullanıcı güncellendi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Users")]
        public IActionResult DeleteUser(DeleteUserRequestDto request)
        {
            try
            {
                _adminService.DeleteUser(request);
                return Ok("Kullanıcı silindi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("Recipes")]
        public IActionResult GetAllRecipes()
        {
            var recipes = _adminService.GetAllRecipes();
            return Ok(recipes);
        }

        [HttpPost("Recipes")]
        public IActionResult AddRecipe(AddRecipeRequestDto request)
        {
            try
            {
                _adminService.AddRecipe(request);
                return Ok("Tarif eklendi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Recipes")]
        public IActionResult UpdateRecipe(UpdateRecipeRequestDto request)
        {
            try
            {
                _adminService.UpdateRecipe(request);
                return Ok("Tarif güncellendi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Recipes")]
        public IActionResult DeleteRecipe(DeleteRecipeRequestDto request)
        {
            try
            {
                _adminService.DeleteRecipe(request);
                return Ok("Tarif silindi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Kategori İşlemleri
        [HttpGet("Categories")]
        public IActionResult GetAllCategories()
        {
            var categories = _adminService.GetAllCategories();
            return Ok(categories);
        }

        [HttpPost("Categories")]
        public IActionResult AddCategory(CreateCategoryRequestDto request)
        {
            try
            {
                _adminService.AddCategory(request);
                return Ok("Kategori eklendi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Categories")]
        public IActionResult UpdateCategory(UpdateCategoryRequestDto request)
        {
            try
            {
                _adminService.UpdateCategory(request);
                return Ok("Kategori güncellendi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Categories")]
        public IActionResult DeleteCategory(DeleteCategoryRequestDto request)
        {
            try
            {
                _adminService.DeleteCategory(request);
                return Ok("Kategori silindi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("User/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(new GetUserByIdRequestDto { UserId = id });
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Kullanıcı getirilirken bir hata oluştu");
            }
        }

    }
}
