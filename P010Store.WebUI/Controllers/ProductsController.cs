using Microsoft.AspNetCore.Mvc;
using P010Store.Service.Abstract;

namespace P010Store.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync(p => p.IsActive);
            return View(model);
        }

        public async Task<IActionResult> Search(string q)
        {
            var model = await _service.GetAllAsync(p => p.IsActive && p.Name.Contains(q));
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var model = await _service.GetProductByCategoriesBrandsAsync(id);
            return View(model);
        }
    }
}
