using Clothing.Application;
using Clothing.Application.Interfaces;
using Clothing.Application.Mappings;
using Clothing.Infrastrucure;
using Clothing.Presentation;
using Clothing.Presentation.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly()));
    cfg.AddProfile(new MappingProfile(typeof(IClothingDbContext).Assembly));
});
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPresentation(builder.Configuration);

Log.Logger = new LoggerConfiguration().ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();
//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Seq("http://localhost:5341")
//    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddAuthorization();

var app = builder.Build();


app.UseCustomHandleExceptions();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
