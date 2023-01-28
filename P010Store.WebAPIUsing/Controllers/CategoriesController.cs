using Microsoft.AspNetCore.Mvc;

namespace P010Store.WebAPIUsing.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
