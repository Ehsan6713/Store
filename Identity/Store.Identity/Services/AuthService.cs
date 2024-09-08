using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Store.Application.Contracts.Identity;
using Store.Application.Models.Identity;
using Store.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Store.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly JWTSettings jWTSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JWTSettings> jWTSettings)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jWTSettings = jWTSettings.Value;
        }
        public async Task<AuthResponse> LogIn(AuthRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception($"{request.Email} is Not Exist");
            }
            var response =await signInManager.PasswordSignInAsync(user,request.Password,false,false);
            if (!response.Succeeded)
            {
                throw new Exception($"Log in Failed");
            }
            var token = await GenerateToken(user);
            return new AuthResponse()
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = request.Email,
                UserName = request.UserName
            };

        }

        public async Task<RegisterationResponse> Register(RegisterationRequest request)
        {
            var userByEmail = await userManager.FindByEmailAsync(request.Email);
            if (userByEmail != null)
            {
                throw new Exception($"{request.Email} is Exists");
            }
            var applicationUser = new ApplicationUser()
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailConfirmed=true
            };
                var response =await userManager.CreateAsync(applicationUser,request.Password);
            if (response.Succeeded)
            {
                await userManager.AddToRoleAsync(applicationUser, "EMPLOYEE");
                return new RegisterationResponse() { UserId = applicationUser.Id };
            }
            throw new Exception($"Error In Registration Occer");
        }


        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser applicationUser)
        {
            var userclaims = await userManager.GetClaimsAsync(applicationUser);
            var userRoles = await userManager.GetRolesAsync(applicationUser);
            List<Claim> userRoleClaims = new List<Claim>();
            foreach (var item in userRoles)
            {
                userRoleClaims.Add(new Claim(ClaimTypes.Role, item));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,applicationUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,applicationUser.Email),
                new Claim("UID",applicationUser.Id),
            }
            .Union(userRoleClaims)
            .Union(userclaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jWTSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jWTSettings.Issuer,
                audience: jWTSettings.Audience,
                expires: DateTime.Now.AddMinutes(jWTSettings.DurationInMinutes),
                claims: claims,
                signingCredentials: signingCredentials
                );
            return jwtSecurityToken;


        }
        public class PasswordHasher
        {
            public static string HashPassword(string password)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }
    }
}
