using Microsoft.AspNetCore.Mvc;

namespace P010Store.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
