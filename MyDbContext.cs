using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pgdemo
{
    public class MyDbContext : DbContext
    {
        private string _connectionString;

        public MyDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }

    public class Product
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID {get;set;}
        public string Name {get;set;}
    }
}
