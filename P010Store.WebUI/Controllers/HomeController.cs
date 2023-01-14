using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.Service.Abstract;
using P010Store.WebUI.Models;
using System.Diagnostics;

namespace P010Store.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Product> _service;
        private readonly IService<Carousel> _serviceCarousel;
        private readonly IService<Brand> _serviceBrand;

        public HomeController(IService<Product> service, IService<Carousel> serviceCarousel, IService<Brand> serviceBrand)
        {
            _service = service;
            _serviceCarousel = serviceCarousel;
            _serviceBrand = serviceBrand;
        }

        public async Task<IActionResult> IndexAsync()
        {

            var model = new HomePageViewModel()
            {
                Carousels = await _serviceCarousel.GetAllAsync(),
                Products = await _service.GetAllAsync(p => p.IsHome),
                Brands = await _serviceBrand.GetAllAsync()
            };
            return View(model);
        }
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}