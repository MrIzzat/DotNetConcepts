using MagicVilla.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Data
{
    public class ApplicationDbContext : DbContext    
    {
        // To add connection string to this class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }




        // The name of this property will be the name of the table in sql server
        public DbSet<Villa> Villa { get; set; }
        //Tools -> Nuget Package Manager -> Package Manager Console
        //Command: add-migration AddVillaTable 
        //To apply SQL to Datbase: update-database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//To add data to table
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id=1,
                    Name="Royal Villa",
                    Details="It is the villa for kings and queens",
                    ImageUrl= "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/fe/c7/a2/one-bedroom-pool-villa.jpg?w=1200&h=-1&s=1",
                    Occupancy=5,
                    Rate=200,
                    Sqft=550,
                    Amenity="",
                    CreateDate= DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Bronze Villa",
                    Details = "It is the villa for Bronze Peuple",
                    ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/fe/c7/a2/one-bedroom-pool-villa.jpg?w=1200&h=-1&s=1",
                    Occupancy = 3,
                    Rate = 50,
                    Sqft = 200,
                    Amenity = "",
                    CreateDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Silver Villa",
                    Details = "It is the villa for Silver People",
                    ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/fe/c7/a2/one-bedroom-pool-villa.jpg?w=1200&h=-1&s=1",
                    Occupancy = 4,
                    Rate = 70,
                    Sqft = 250,
                    Amenity = "",
                    CreateDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Gold Villa",
                    Details = "It is the villa for Gold People",
                    ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/fe/c7/a2/one-bedroom-pool-villa.jpg?w=1200&h=-1&s=1",
                    Occupancy = 5,
                    Rate = 100,
                    Sqft = 350,
                    Amenity = "",
                    CreateDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 5,
                    Name = "Diamond Villa",
                    Details = "It is the villa for Diamond People",
                    ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/fe/c7/a2/one-bedroom-pool-villa.jpg?w=1200&h=-1&s=1",
                    Occupancy = 6,
                    Rate = 250,
                    Sqft = 400,
                    Amenity = "",
                    CreateDate = DateTime.Now
                }




                );
        }//To add the new villas to database: add-migration SeedVillaTable
        //To modify the migration:  add-migration SeedVillaTableWithCreatedDate
        //Then: update-database


    }// The connection string is added to the applicationsettings.json file
}
