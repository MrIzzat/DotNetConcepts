using AutoMapping.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoMapping.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1FGNE6J\\ASPNET;Database=ORM;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    

    }
}
