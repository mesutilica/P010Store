using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.Service.Abstract;

namespace P010Store.WebAPIUsing.ViewComponents
{
    public class Categories : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7141/Api/Categories";

        public Categories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdres);
            return View(model);
        }

    }
}
