using Microsoft.AspNetCore.Mvc;
using Store.MVC.Models;

namespace Store.MVC.Contracts
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
    }
}
