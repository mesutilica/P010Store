using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.Service.Abstract;
using P010Store.WebUI.Utils;

namespace P010Store.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly IService<Brand> _service; // veritabanı işlemleri için generic olarak tasarladığımız repository sınıfını kullanan service interface ini brand class ı için kullanılmak üzere tanımladık.

        public BrandsController(IService<Brand> service)
        {
            _service = service;
        }

        // GET: BrandsController
        public IActionResult Index()
        {
            //var model = _service.GetAll();
            List<Brand> brands = _service.GetAll();

            return View(brands);
        }

        // GET: BrandsController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: BrandsController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BrandsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Brand brand, IFormFile? Logo)
        {
            if (ModelState.IsValid) // Model class ımız olan brand nesnesinin validasyon için koyduğumuz kurallarınıa (örneğin marka adı required-boş geçilemez gibi) uyulmuşsa
            {
                try
                {
                    brand.Logo = await FileHelper.FileLoaderAsync(Logo);
                    _service.Add(brand);
                    _service.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            
            return View(brand);
        }
        
        // POST: BrandsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2(Brand brand, IFormFile? Logo)
        {
            if (ModelState.IsValid) // Model class ımız olan brand nesnesinin validasyon için koyduğumuz kurallarınıa (örneğin marka adı required-boş geçilemez gibi) uyulmuşsa
            {
                try
                {
                    brand.Logo = await FileHelper.FileLoaderAsync(Logo);
                    _service.Add(brand);
                    _service.SaveChanges();
                    return RedirectToAction("Create", "Products");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            
            return View(brand);
        }

        // GET: BrandsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: BrandsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Brand brand, IFormFile? Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(Logo is not null) brand.Logo = await FileHelper.FileLoaderAsync(Logo);
                    _service.Update(brand);
                    _service.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(brand);
        }

        // GET: BrandsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: BrandsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Brand brand)
        {
            try
            {
                _service.Delete(brand);
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
