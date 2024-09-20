using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.MVC.Contracts;
using Store.MVC.Models.PersonViewModels;

namespace Store.MVC.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private readonly IPersonServices PersonServices;

        public PersonController(IPersonServices PersonServices)
        {
            this.PersonServices = PersonServices;
        }
        // GET: PersonController
        public async Task<ActionResult> Index()
        {
            ViewData.Model = await PersonServices.GetAll();
            return View();
        }

        // GET: PersonController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ViewData.Model = await PersonServices.Get(id);
            return View();
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View(new PersonVM());
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PersonVM model)
        {
            try
            {
                var result = await PersonServices.Create(model);
                if (result.Success)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        // GET: PersonController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewData.Model = await PersonServices.Get(id);
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PersonVM model)
        {
            try
            {
                var result = await PersonServices.Update(id, model);
                if (result.Success)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        // GET: PersonController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ViewData.Model = await PersonServices.Get(id);
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, PersonVM model)
        {
            try
            {
                var result = await PersonServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
