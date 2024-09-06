using Store.MVC.Contracts;
using Store.MVC.Services.Base;
using Store.MVC.Services;
using System.Reflection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Host.UseSerilog((ctx, lc) => lc.
WriteTo.Console()
 .WriteTo.File("log.txt")
 .WriteTo.MSSqlServer(
        connectionString: ctx.Configuration.GetConnectionString("LogStore"),
        sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
        {
            TableName = "Logs",
            AutoCreateSqlTable = true,

        })
 );


builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient(); // Register HttpClient separately

// Retrieve ApiUrl from configuration
string apiUrl = builder.Configuration.GetValue<string>("ApiUrl");

// Register Client with the required parameters
builder.Services.AddScoped<IClient>(provider =>
{
    var httpClient = provider.GetRequiredService<System.Net.Http.HttpClient>();
    return new Client(apiUrl, httpClient);
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();

// Add other services
builder.Services.AddScoped<IAttachmentServices, AttachmentServices>();
builder.Services.AddScoped<IBrandServices, BrandServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IOrderDetailServices, OrderDetailServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IPersonServices, PersonServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();

builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
