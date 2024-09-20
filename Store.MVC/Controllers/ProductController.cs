using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.MVC.Contracts;
using Store.MVC.Models.ProductViewModels;

namespace Store.MVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductServices ProductServices;

        public ProductController(IProductServices ProductServices)
        {
            this.ProductServices = ProductServices;
        }
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            ViewData.Model = await ProductServices.GetAll();
            return View();
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ViewData.Model = await ProductServices.Get(id);
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View(new ProductVM());
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductVM model)
        {
            try
            {
                var result = await ProductServices.Create(model);
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

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewData.Model = await ProductServices.Get(id);
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductVM model)
        {
            try
            {
                var result = await ProductServices.Update(id, model);
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

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ViewData.Model = await ProductServices.Get(id);
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ProductVM model)
        {
            try
            {
                var result = await ProductServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
