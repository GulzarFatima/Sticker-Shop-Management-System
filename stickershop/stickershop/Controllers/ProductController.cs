using Microsoft.AspNetCore.Mvc;

namespace stickershop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
