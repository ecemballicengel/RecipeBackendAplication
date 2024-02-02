using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Bll.Services.AmountTypeServices;
using Recipe.Dtos.Request;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AmountTypeController : ControllerBase
    {
        private readonly IAmountTypeService _amountTypeService;

        public AmountTypeController(IAmountTypeService amountTypeService)
        {
            _amountTypeService = amountTypeService;
        }

        [HttpPost]
        public IActionResult CreateAmountType(CreateAmountTypeRequestDto request) 
        {
            _amountTypeService.CreateAmountType(request);
            return Ok("Miktar Tipleri eklendi");
        }
        [HttpPut]
        public IActionResult UpdateAmountType(UpdateAmountTypeRequestDto request)
        {
            _amountTypeService.UpdateAmountType(request);
            return Ok("Miktar tipi guncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteAmountType(DeleteAmountTypeRequestDto request)
        {
            _amountTypeService.DeleteAmountType(request);
            return Ok("Miktar tipi silindi");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAmountTypes()
        {
            var data = _amountTypeService.GetAmountTypes();
            return Ok(data);
        }
    }
}
