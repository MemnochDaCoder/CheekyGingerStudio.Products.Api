using Infrastructure.Options;
using Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories.Interfaces;
using Domain.Events;
using Application.Services;
using Application.Factories.Interfaces;
using Application.Factories;

var builder = WebApplication.CreateBuilder(args);

// Configure PostgreSQL options
builder.Services.AddOptions<PostGresOptions>()
            .BindConfiguration("ConnectionStrings:PostGres");

// Configure DbContext
builder.Services.AddDbContext<CheekyGingerStudioDbContext>((serviceProvider, options) =>
{
    var postgresOptions = serviceProvider.GetRequiredService<IOptions<PostGresOptions>>().Value;
    options.UseNpgsql(postgresOptions.ConnectionString);
});

// Register repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Register domain services
builder.Services.AddScoped<IProductService, ProductService>();

// Register factories
builder.Services.AddScoped<IProductFactory, ProductFactory>();

// Add controllers
builder.Services.AddControllers();

// Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cheeky Ginger Studio Product API", Version = "v1" });
});

var app = builder.Build();

// Enable Swagger and Swagger UI in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cheeky Ginger Studio API V1");
        c.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// HTTPS redirection
app.UseHttpsRedirection();

// Static files and routing
app.UseStaticFiles();
app.UseRouting();

// Authorization
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
