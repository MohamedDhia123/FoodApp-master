using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
