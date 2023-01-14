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
    }
}
