using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Bll.Services.StripeServices;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IStripeService _stripeService;

        public PaymentController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpGet]
        public IActionResult Payment()
        {
           var data = _stripeService.PaymentIntent();
            return Ok(data);
        }
    }
}
