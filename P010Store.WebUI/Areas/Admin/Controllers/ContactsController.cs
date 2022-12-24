using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P010Store.Entities;
using P010Store.Service.Abstract;

namespace P010Store.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactsController : Controller
    {
        private readonly IService<Contact> _service;

        public ContactsController(IService<Contact> service)
        {
            _service = service;
        }

        // GET: ContactsController
        public ActionResult Index()
        {
            var model = _service.GetAll();
            return View(model);
        }

        // GET: ContactsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            try
            {
                _service.Add(contact);
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactsController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _service.Find(id);
            return View(model);
        }

        // POST: ContactsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contact contact)
        {
            try
            {
                _service.Update(contact);
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactsController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _service.Find(id);
            return View(model);
        }

        // POST: ContactsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Contact contact)
        {
            try
            {
                _service.Delete(contact);
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
