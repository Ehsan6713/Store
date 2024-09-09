using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Store.MVC.Contracts;
using Store.MVC.Models;
using Store.MVC.Services.Base;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Store.MVC.Services
{
    public class AuthenticateService : BaseHttpService, IAuthenticateService
    {
        private readonly ILocalStorageService storage;
        private readonly IClient client;
        private readonly IHttpContextAccessor httpContextAccessor;
        private JwtSecurityTokenHandler jwtSecurityTokenHandler;
        public AuthenticateService(ILocalStorageService storage, IClient client, IHttpContextAccessor httpContextAccessor) : base(storage, client)
        {
            this.storage = storage;
            this.client = client;
            this.httpContextAccessor = httpContextAccessor;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public async Task<bool> Authenticate(LoginVM loginmodel)
        {
            try
            {
                var request = new AuthRequest()
                {
                    Email = loginmodel.Email,
                    Password = loginmodel.Password,
                    UserName = loginmodel.Email
                };
                var response = await client.LoInAsync(request);
                if (response != null && !string.IsNullOrEmpty(response.Token))
                {
                    var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(response.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(
                        new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);

                    storage.SetStorageValue("token", response.Token);
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }

        public async Task LogOut()
        {
            storage.ClearStorage(new List<string>() { "token" });
            await httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> Register(RegisterVM request)
        {
            var resisterVm = new RegisterationRequest()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password
            };
            var response = await client.RegisterAsync(resisterVm);
            if (!string.IsNullOrEmpty(response.UserId))
                return true;
            return false;
        }
        private IList<Claim> ParseClaims(JwtSecurityToken token)
        {
            var claims = token.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, token.Subject));
            return claims;
        }
    }
}
