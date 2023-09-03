using CarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAPI.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }

        public DbSet<Car> Car { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car()
                {
                    Id=1,
                    Vin=123,
                    Manufacturer="BMW",
                    Model="M5",
                    EngineSize=2000,
                    Price=25000,
                    HasTurbo=true,
                    Fuel="Diesel",
                    CreateDate=DateTime.Now
                },
                new Car()
                {
                    Id = 2,
                    Vin = 931,
                    Manufacturer = "Lamborghini",
                    Model = "Hurcan",
                    EngineSize = 3000,
                    Price = 35000,
                    HasTurbo = true,
                    Fuel = "Petrol",
                    CreateDate = DateTime.Now
                },
                new Car()
                {
                    Id = 3,
                    Vin = 323,
                    Manufacturer = "Tesla",
                    Model = "X",
                    EngineSize = -1,
                    Price = 10000,
                    HasTurbo = false,
                    Fuel = "electricity",
                    CreateDate = DateTime.Now
                }


                );
        }


    }
}
