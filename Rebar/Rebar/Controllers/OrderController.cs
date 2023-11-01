using Microsoft.AspNetCore.Mvc;
using Rebar.Models;
using Rebar.Services;

namespace Rebar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService service)
        {
            _orderService = service;
        }

        [HttpPost]
        public IActionResult AddOrder(string clientName, List<UserOrderShake> userOrderShakes)
        {
            DateTime startOrder = DateTime.Now;
            try
            {
                _orderService.AddOrder(clientName, userOrderShakes, startOrder);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
