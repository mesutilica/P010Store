using Microsoft.AspNetCore.Mvc;
using P010Store.Service.Abstract;
using P010Store.WebUI.Models;

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
            var product = await _service.GetProductByCategoriesBrandsAsync(id);
            var model = new ProductDetailViewModel()
            {
                Product = product,
                Products = await _service.GetAllAsync(p => p.CategoryId == product.CategoryId && p.Id != id)
            };

            return View(model);
        }
    }
}
