using Microsoft.AspNetCore.Mvc;
using Store.MVC.Contracts;
using Store.MVC.Models.CategoryViewModels;

namespace Store.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices CategoryServices;

        public CategoryController(ICategoryServices CategoryServices)
        {
            this.CategoryServices = CategoryServices;
        }
        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            ViewData.Model = await CategoryServices.GetAll();
            return View();
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ViewData.Model = await CategoryServices.Get(id);
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View(new CategoryVM());
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryVM model)
        {
            try
            {
                var result = await CategoryServices.Create(model);
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

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewData.Model = await CategoryServices.Get(id);
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CategoryVM model)
        {
            try
            {
                var result = await CategoryServices.Update(id, model);
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

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ViewData.Model = await CategoryServices.Get(id);
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, CategoryVM model)
        {
            try
            {
                var result = await CategoryServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
