using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Chef_Helper_API.Controllers;
using Microsoft.EntityFrameworkCore;

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
