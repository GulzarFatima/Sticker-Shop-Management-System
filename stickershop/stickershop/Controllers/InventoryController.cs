using Microsoft.AspNetCore.Mvc;

namespace stickershop.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
