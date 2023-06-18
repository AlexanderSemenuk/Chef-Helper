using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Chef_Helper_API.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

namespace Chef_Helper_API
{
    public class Program
    {
        public static async void Main(string[] args)
        {
            using (ChefdbContext db = new ChefdbContext()) { 
                db.Database.EnsureCreated();
                db.Database.CanConnect();
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // Добавляем DbContext в DI-контейнер
                services.AddDbContext<ChefdbContext>(options =>
                    options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));

                // Добавляем контроллеры в DI-контейнер
                services.AddControllers();
            });
    }
}
