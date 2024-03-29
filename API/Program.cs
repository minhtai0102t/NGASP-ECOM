using Ecom_API.Authorization;
using Ecom_API.Config;
using Ecom_API.DBHelpers;
using Ecom_API.Helpers;
using Microsoft.EntityFrameworkCore;
using Services.CommonConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddCors();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// configure automapper with all automapper profiles from this assembly
services.AddAutoMapper(typeof(Program));

// configure strongly typed settings object
services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
services.DIConfiguration();

//connection string
services.AddDbContext<ApiDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Connection"), b => b.MigrationsAssembly("Ecom-API")));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}
app.Run();

