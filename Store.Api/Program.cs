using Microsoft.OpenApi.Models;
using Store.Application;
using Store.Identity;
using Store.Infrastructure;
using Store.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(o =>
{
    o.AddPolicy("corspolicy", b =>

        b.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod()
    );
});

// Add services to the container.
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.RegisterIdentityServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
AddSwager(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseCors("corspolicy");
app.UseAuthorization();


app.MapControllers();

app.Run();


void AddSwager(IServiceCollection services)
{
    services.AddSwaggerGen(option =>
    {
        option.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
        {
            Description = @"Enter 'Bearer' [space] and then your token in the text input below. 
                            Example: 'Bearer abcdef12345'.",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        option.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
            new OpenApiSecurityScheme()
            {
                Reference=new OpenApiReference()
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Scheme="oauth2",
                Name="Bearer",
                In=ParameterLocation.Header
            },
            new List<string>()
        }
        }
        );
        option.SwaggerDoc("v1", new OpenApiInfo()
        {
            Version = "v1",
            Title = "Store Api"
        });

    });

}