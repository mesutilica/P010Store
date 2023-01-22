using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.WebAPIUsing.Utils;
using System.Drawing.Drawing2D;

namespace P010Store.WebAPIUsing.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class CarouselController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7141/Api/Carousel";

        public CarouselController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: CarouselController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Carousel>>(_apiAdres);
            return View(model);
        }

        // GET: CarouselController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarouselController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarouselController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Carousel carousel, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) 
                        carousel.Image = await FileHelper.FileLoaderAsync(Image);
                    var response = await _httpClient.PostAsJsonAsync(_apiAdres, carousel);
                    if (response.IsSuccessStatusCode) 
                        return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(carousel);
        }

        // GET: CarouselController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Carousel>(_apiAdres + "/" + id);
            return View(model);
        }

        // POST: CarouselController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Carousel carousel, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) carousel.Image = await FileHelper.FileLoaderAsync(Image);
                    await _httpClient.PutAsJsonAsync(_apiAdres + "/" + id, carousel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(carousel);
        }

        // GET: CarouselController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Carousel>(_apiAdres + "/" + id);
            return View(model);
        }

        // POST: CarouselController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
        {
            try
            {
                await _httpClient.DeleteAsync(_apiAdres + "/" + id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
