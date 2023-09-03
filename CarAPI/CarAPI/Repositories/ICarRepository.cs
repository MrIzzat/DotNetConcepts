using CarAPI.Models.DTO;
using CarAPI.Models;
using CarAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CarAPI.Repositories
{
    public interface ICarRepository 
    {

        public IEnumerable<Car> Get();

        public Car? GetById(int carId);

        public Car? GetByVin(int vin);
        public Car? GetByVinNoTracking(int vin);
        public Car? GetByIdNoTracking(int vin);


        public void Add(Car Car);

        public void Delete(Car Car);



        public void Update(Car Car);

        public void Save();


    }
}
