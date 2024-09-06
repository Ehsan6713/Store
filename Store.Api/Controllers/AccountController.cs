using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Contracts.Identity;
using Store.Application.Models.Identity;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("LoIn")]
        public async Task<ActionResult<AuthResponse>> LoIn(AuthRequest authRequest)
        {
           return  Ok(await authService.LogIn(authRequest));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterationResponse>> Registeration(RegisterationRequest registerationRequest)
        {
            return Ok(await authService.Register(registerationRequest));
        }
    }
}
