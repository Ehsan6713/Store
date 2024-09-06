using Store.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> LogIn(AuthRequest request);
        Task<RegisterationResponse> Register(RegisterationRequest request);
    }
}
