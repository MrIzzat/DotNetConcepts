using CarAPI.Models;
using CarAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CarAPI.Services.CarServices
{
    public interface ICarService
    {
        public IEnumerable<Car> Get();

        public Car GetById(int carId);

        public Car GetByVin(int vin);


        public void Add(CarDTO carDTO);

        public void DeleteById(int Id);

        public void DeleteByVin(int vin);

        public void Update(CarDTO carDTO);

        public void UpdatePartiallyByVin(int Vin, JsonPatchDocument<CarDTO> pathDTO);

        public void updatePartiallyById(int Id, JsonPatchDocument<CarDTO> pathDTO);

    }
}
