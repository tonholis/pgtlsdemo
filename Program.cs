using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pgdemo
{
    class Program
    {
        static async Task Main(string[] args)
        {   
            string host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
            string database = Environment.GetEnvironmentVariable("DB_NAME") ?? "myapp";
            string username = Environment.GetEnvironmentVariable("DB_USER") ?? "myapp";
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "secret";

            var db = new MyDbContext($"Host={host};Database={database};Username={username};Password={password};SSL Mode=Require;Trust Server Certificate=true");
            db.Database.Migrate();

            db.Products.Add(new Product { Name="Banana" });
            await db.SaveChangesAsync();

            var count = await db.Products.CountAsync();
            Console.WriteLine($"Count={count}");
        }
    }
}
