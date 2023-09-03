using ContosoPizza.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_Learning.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1FGNE6J\\ASPNET;Database=EntityFrameWorkCore_Learning;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=True");

        }

    }
}
