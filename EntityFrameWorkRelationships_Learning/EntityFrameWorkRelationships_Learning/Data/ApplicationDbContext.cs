using EntityFrameWorkRelationships_Learning.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkRelationships_Learning.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }
        //Update-Database -Migration:0 removes all migrations from database
        
        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Faction> Factions { get; set; }

    }
}
