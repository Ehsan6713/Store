using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.MVC.Contracts;
using Store.MVC.Models.Brands;

namespace Store.MVC.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandServices brandServices;

        public BrandController(IBrandServices brandServices)
        {
            this.brandServices = brandServices;
        }
        // GET: BrandController
        public async Task<ActionResult> Index()
        {
            ViewData.Model = await brandServices.GetAll();
            return View();
        }

        // GET: BrandController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ViewData.Model = await brandServices.Get(id);
            return View();
        }

        // GET: BrandController/Create
        public ActionResult Create()
        {
            return View(new BrandVM());
        }

        // POST: BrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BrandVM model)
        {
            try
            {
                var result = await brandServices.Create(model);
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

        // GET: BrandController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewData.Model = await brandServices.Get(id);
            return View();
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BrandVM model)
        {
            try
            {
                var result = await brandServices.Update(id, model);
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

        // GET: BrandController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ViewData.Model = await brandServices.Get(id);
            return View();
        }

        // POST: BrandController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, BrandVM model)
        {
            try
            {
                var result = await brandServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
