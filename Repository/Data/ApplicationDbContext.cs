using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1FGNE6J\\ASPNET;Database=ORM;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=True");

        }

        public DbSet<WeatherForecast> Forecasts { get; set; }

    }
}
