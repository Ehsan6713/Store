using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSettings").Value, x =>
            {
                x.Host = x.Host ?? "smtp.gmail.com";
                x.Port = x.Port;
                x.FromAddress = x.FromAddress;
                x.FromPassword = x.FromPassword;
                x.FromName = x.FromName;
            });
            return services;
        }
    }
}
