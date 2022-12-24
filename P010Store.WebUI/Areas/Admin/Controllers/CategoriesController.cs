using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.Service.Abstract;
using P010Store.WebUI.Utils;

namespace P010Store.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IService<Category> _service;

        public CategoriesController(IService<Category> service)
        {
            _service = service;
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            var model = _service.GetAll();
            return View(model);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Category category, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) category.Image = await FileHelper.FileLoaderAsync(Image);
                    await _service.AddAsync(category);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(category);
        }

        // GET: CategoriesController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Category category, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) category.Image = await FileHelper.FileLoaderAsync(Image);
                    _service.Update(category);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(category);
        }

        // GET: CategoriesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                _service.Delete(category);
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
