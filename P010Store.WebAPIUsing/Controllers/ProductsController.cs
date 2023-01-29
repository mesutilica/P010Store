using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.WebAPIUsing.Models;

namespace P010Store.WebAPIUsing.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7141/Api/";

        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Product>>(_apiAdres + "Products");
            return View(model);
        }
        public async Task<IActionResult> Search(string q)
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>(_apiAdres + "Products");
            var model = products.Where(p => p.IsActive && p.Name.ToLower().Contains(q.ToLower()));
            return View(model);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>(_apiAdres + "Products"); // ürünleri api üzerinden çektik
            var product = products.FirstOrDefault(p => p.Id == id); // api den çektiğimiz listeden route dan gelen id ile eşleşen kaydı bulduk
            var model = new ProductDetailViewModel()
            {
                Product = product, // model içindeki ürün
                Products = products.Where(p => p.CategoryId == product.CategoryId && p.Id != id).Take(4).ToList()// aynı kategorideki diğer ürünler
            };
            return View(model);
        }
    }
}
