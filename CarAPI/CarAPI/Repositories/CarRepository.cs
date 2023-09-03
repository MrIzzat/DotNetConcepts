using CarAPI.DataAccess;
using CarAPI.Models;
using CarAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace CarAPI.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(Car Car)
        {
            _db.Car.Add(Car);
        }

        public void Delete(Car Car)
        {
            _db.Car.Remove(Car);
        }

        public IEnumerable<Car> Get()
        {
            return _db.Car;
        }

        public Car? GetById(int carId)
        {
           return _db.Car.FirstOrDefault(c => c.Id == carId);
        }
        public Car? GetByIdNoTracking(int carId)
        {
            return _db.Car.AsNoTracking().FirstOrDefault(c => c.Id == carId);
        }

        public Car? GetByVin(int Vin)
        {
            return _db.Car.FirstOrDefault(u => u.Vin == Vin);
        }
        public Car? GetByVinNoTracking(int Vin)
        {
            return _db.Car.AsNoTracking().FirstOrDefault(u => u.Vin == Vin);
        }


        public void Update(Car Car)
        {
           _db.Car.Update(Car);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        
    }
}
