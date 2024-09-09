using Store.MVC.Models;
using Store.MVC.Services.Base;

namespace Store.MVC.Contracts
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(LoginVM request);
        Task<bool> Register(RegisterVM request);
        Task LogOut();
    }
}
