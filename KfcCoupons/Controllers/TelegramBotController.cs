using Microsoft.AspNetCore.Mvc;

namespace KfcCoupons.Controllers
{
    [Route("api/[controller]")]
    public class TelegramBotController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

    }
}