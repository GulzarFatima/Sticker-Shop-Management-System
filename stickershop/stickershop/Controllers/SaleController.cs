using Microsoft.AspNetCore.Mvc;

namespace stickershop.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
