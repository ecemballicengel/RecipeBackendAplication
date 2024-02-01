using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Bll.Services.CategoryServices;
using Recipe.Dtos.Request;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
          var categoryList = _categoryService.GetCategortyList();

          return Ok(categoryList);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryRequestDto request)
        {
            _categoryService.CreateCategory(request);
            return Ok("Kategoriler eklendi");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryRequestDto request)
        {
            _categoryService.UpdateCategory(request);
            return Ok("Kategoryler guncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(DeleteCategoryRequestDto request) 
        {
            _categoryService.DeleteCategory(request);
            return Ok("Kategori silindi");
        }
    }
}
