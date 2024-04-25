using Microsoft.AspNetCore.Mvc;
using FoodApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using FoodApp.ContextDBConfig;

namespace FoodApp.Controllers
{
    public class RecipeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FoodAppDBContext context;
        public RecipeController(UserManager<ApplicationUser> userManager, FoodAppDBContext dBContext)
        {
            _userManager = userManager;
            context = dBContext ;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetRecipeCard([FromBody] List<Recipe> recipes)
        {
            return PartialView("_Recipecard",recipes);
        }

        public ActionResult Search([FromQuery] string recipe)
        {
            ViewBag.Recipe = recipe;
            return View();
        }

        public ActionResult Order([FromQuery] string id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ShowOrder(OrderRecipeDetails orderRecipeDetails)
        {
            Random random = new Random();
            ViewBag.Price = Math.Round(random.Next(150, 500)/5.0)*5;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.UserId = user?.Id;
            ViewBag.Address = user?.Address;
            return PartialView("_ShowOrder", orderRecipeDetails);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Order([FromForm]Order order)
        {
            order.OrderDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return RedirectToAction("Index", "Recipe");
            }
            return RedirectToAction("Order", "Recipe", new {id=order.Id});
        }

    }
}
