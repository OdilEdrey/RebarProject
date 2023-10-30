using Microsoft.AspNetCore.Mvc;

namespace Rebar.Controllers
{
    public class ShakeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
