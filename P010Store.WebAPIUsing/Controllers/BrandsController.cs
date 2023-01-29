using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.WebAPIUsing.Models;

namespace P010Store.WebAPIUsing.Controllers
{
    public class BrandsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7141/api/";

        public BrandsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> IndexAsync(int id)
        {
            var marka = await _httpClient.GetFromJsonAsync<Brand>(_apiAdres + "Brands/" + id);
            var products = await _httpClient.GetFromJsonAsync<List<Product>>(_apiAdres + "Products");
            var model = new BrandPageViewModel()
            {
                Brand = marka,
                Products = products.Where(p => p.IsActive && p.BrandId == id).ToList()
            };
            return View(model);
        }
    }
}
