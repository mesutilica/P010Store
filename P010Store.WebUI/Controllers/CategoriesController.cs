using Microsoft.AspNetCore.Mvc;
using P010Store.Service.Abstract;

namespace P010Store.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _service.GetCategoryByProducts(id);
            return View(model);
        }
    }
}
