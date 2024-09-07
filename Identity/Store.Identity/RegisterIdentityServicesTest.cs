using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Identity
{
    public static class RegisterIdentityServicesTest
    {
        public static IServiceCollection ConfigureIdentityServicces(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            services.AddDbContext<IdentityDbContext>(option => option.UseSqlServer(configuration.GetSection("connectionstring").Value,x=>x.MigrationsAssembly(Assembly.GetExecutingAssembly().ToString())));


            return services;
        }
    }
}
