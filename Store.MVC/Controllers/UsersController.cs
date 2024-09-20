using Microsoft.AspNetCore.Mvc;
using Store.MVC.Contracts;
using Store.MVC.Models;

namespace Store.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticateService authenticateService;

        public UsersController(IAuthenticateService authenticateService)
        {
            this.authenticateService = authenticateService;
        }
        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var response = await authenticateService.Authenticate(model);
            if (response)
                return LocalRedirect(returnUrl);
            ModelState.AddModelError("", "Error Faild");
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await authenticateService.Register(model);
            if (result)
                return LocalRedirect("/");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await authenticateService.LogOut();
            return LocalRedirect("/Users/Login");
        }
    }
}
