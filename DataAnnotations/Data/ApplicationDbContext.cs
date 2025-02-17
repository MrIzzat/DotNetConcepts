using DataAnnotations.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAnnotations.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1FGNE6J\\ASPNET;Database=FluentApi;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }
        //Update-Database -Migration:0 removes all migrations from database
        
        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Faction> Factions { get; set; }


    /*    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }*/

    }
}
