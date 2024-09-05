using Hanssens.Net;
using Store.MVC.Contracts;
using Store.MVC.Services;
using Store.MVC.Services.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddHttpClient<IClient, Client>(x => x.BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Value));
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
