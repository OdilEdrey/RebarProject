using Microsoft.AspNetCore.Mvc;
using Rebar.Models;
using Rebar.Services;

namespace Rebar.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ShakeController : Controller
    {
        private readonly IShakeService _shakeService;
        public ShakeController(IShakeService service)
        {
            _shakeService = service;
        }

        [HttpPost]
        public IActionResult AddShakes(Shake shake)
        {
            try
            {
               _shakeService.AddShake(shake.Name, shake.Description, shake.PriceLarge, shake.PriceMedium, shake.PriceSmall);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Shake>>  GetShakesList()
        {
            try
            {
                List<Shake> shakes = _shakeService.GetAllShakes();
                return Ok(shakes);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
