using AutoMapper;
using CarAPI.Models;
using CarAPI.Models.DTO;
using CarAPI.Repositories;
using CarAPI.Services.CarServices.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CarAPI.Services.CarServices
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository,IMapper mapper)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }
        public void Add(CarDTO carDTO)
        {
            if (carDTO.Id != 0)
            {

                CarBadRequestException badRequestException = new()
                {
                    Cause = "InvalidCarId",
                    Information = "Any ID other than Zero is not Accepted!"

                };
                throw badRequestException;
                
            }

            if (carDTO == null)
            {
                CarBadRequestException badRequestException = new()
                {
                    Cause = "NullCar",
                    Information = "Car Object is Null"

                };
                throw badRequestException;
                
            }


            
            if (_carRepository.GetByVin(carDTO.Vin) != null)
            {

                CarBadRequestException badRequestException = new()
                {
                    Cause = "VinDuplication",
                    Information = "Car With that VIN already exists !"

                };
                throw badRequestException;

                
            }


            if (carDTO.Fuel.ToLower() == "diesel" && carDTO.HasTurbo == false)
            {
                CarBadRequestException badRequestException = new()
                {
                    Cause = "DieselMustHaveTurbo",
                    Information = "All Deisel Vehicles Must have A Turbo !"

                };
                throw badRequestException;
                
            }
            if (carDTO.EngineSize > 4000)
            {
                CarBadRequestException badRequestException = new()
                {
                    Cause = "EngineSizeTooBig",
                    Information = "A Car Cannot have an Engine Size of over 4000 Cubic Inches !"

                };
                throw badRequestException;
               
            }
            if (carDTO.Fuel.ToLower() != "diesel" && carDTO.Fuel.ToLower() != "vegetable oil" &&
                carDTO.Fuel.ToLower() != "petrol" && carDTO.Fuel.ToLower() != "electricity")
            {
                CarBadRequestException badRequestException = new()
                {
                    Cause = "InvalidFuel",
                    Information = "Fuel Must be Diesel, Petrol, Vegetable Oil or Electricity!"

                };
                throw badRequestException;
               
            }

            carDTO.Fuel = carDTO.Fuel.ToLower();
            Car newCar = _mapper.Map<Car>(carDTO);
            newCar.CreateDate = DateTime.Now;

            _carRepository.Add(newCar);
            _carRepository.Save();


        }

        public void DeleteById(int Id)
        {
            var oldCar = GetById(Id);

            _carRepository.Delete(oldCar);
            _carRepository.Save();
        }

        public void DeleteByVin(int Vin)
        {
            var oldCar = GetByVin(Vin);
            _carRepository.Delete(oldCar);
            _carRepository.Save();

        }

        public IEnumerable<Car> Get()
        {
            return _carRepository.Get();
        }

        public Car GetById(int Id)
        {

            if (Id < 1) 
            {
                CarBadRequestException badRequestException = new()
                {
                    Cause = "CarIdIsZero",
                    Information = "Car Id Must Not Be Less Than One"

                };

                throw badRequestException;
            }

            var car = _carRepository.GetById(Id);
                
            if (car == null)
            {
                CarNotFoundException notFoundException = new()
                {
                    Cause = "CatNotFound",
                    Information = "Car with that Id Does not Exist !"

                };

                throw notFoundException;

            }

            return car;
        }

        public Car GetByVin(int Vin)
        {
            if (Vin < 0)
            {
                CarBadRequestException badRequestException = new()
                {
                    Cause = "CarVinIsZero",
                    Information = "Car VIN Must Not Be Less than ZERO !"

                };
                throw badRequestException; 
            }

            var car = _carRepository.GetByVin(Vin);

            if (car == null)
            {
                CarNotFoundException notFoundException = new()
                {
                    Cause = "CarNotFound",
                    Information = "Car with that VIN was not found !"

                };
                throw notFoundException;
            }

            return car;
        }

        public void Update(CarDTO carDTO)
        {
            if (carDTO.Id != 0)
            {
                CarBadRequestException badRequestException = new()
                {
                    Cause = "InvalidCarId",
                    Information = "Any ID other than Zero is not Accepted!"

                };
                throw badRequestException;
                
            }

            if (carDTO == null)
            {
                CarBadRequestException badRequestException = new()
                {
                    Cause = "NullCar",
                    Information = "Car Object is Null"

                };
                throw badRequestException;
                
            }
            if (carDTO.Fuel.ToLower() == "diesel" && carDTO.HasTurbo == false)
            {
                CarBadRequestException badRequestException = new()
                {
                    Cause = "DieselMustHaveTurbo",
                    Information = "All Deisel Vehicles Must have A Turbo !"

                };
                throw badRequestException;
               
            }
            if (carDTO.EngineSize > 4000)
            {
                CarBadRequestException badRequestException = new()
                {
                    Cause = "EngineSizeTooBig",
                    Information = "A Car Cannot have an Engine Size of over 4000 Cubic Inches !"

                };
                throw badRequestException;
                
            }
            if (carDTO.Fuel.ToLower() != "diesel" && carDTO.Fuel.ToLower() != "vegetable oil" &&
                carDTO.Fuel.ToLower() != "petrol" && carDTO.Fuel.ToLower() != "electricity")
            {
                CarBadRequestException badRequestException = new()
                {
                    Cause = "InvalidFuel",
                    Information = "Fuel Must be Diesel, Petrol, Vegetable oil or Electricity!"

                };
                throw badRequestException;

                
            }

            var dbCar = _carRepository.GetByVinNoTracking(carDTO.Vin);
           
            if (dbCar == null)
            {
                CarNotFoundException notFoundException = new()
                {
                    Cause = "VinNotFound",
                    Information = "Car With that VIN Does Not Exist !"

                };
                throw notFoundException;
            }


            carDTO.Fuel.ToLower();

            var newCar = _mapper.Map<Car>(carDTO);

            newCar.Id = dbCar.Id;
            newCar.UpdateDate = DateTime.Now;
            newCar.CreateDate = dbCar.CreateDate;

            

            _carRepository.Update(newCar);
            _carRepository.Save();
        }

        public void updatePartiallyById(int Id, JsonPatchDocument<CarDTO> pathDTO)
        {
            if (Id < 1)
            {
                CarBadRequestException badRequestException = new()
                {
                    Cause = "InvalidID",
                    Information = "ID Must Not Be Below One !"

                };
                throw badRequestException;
                
            }

            var OldCar = _carRepository.GetByIdNoTracking(Id);

            if (OldCar == null)
            {
                CarNotFoundException notFoundException = new()
                {
                    Cause = "IdNotFound",
                    Information = "Car with This Id does not Exist !"

                };
                throw notFoundException;
                
            }

            var NewCar = _mapper.Map<CarDTO>(OldCar);

            pathDTO.ApplyTo(NewCar);


            var NewCarToDatabase = _mapper.Map<Car>(NewCar);
            NewCarToDatabase.UpdateDate = DateTime.Now;
            NewCarToDatabase.CreateDate = OldCar.CreateDate;
            NewCarToDatabase.Fuel = NewCarToDatabase.Fuel.ToLower();

            _carRepository.Update(NewCarToDatabase);

            _carRepository.Save();


          
        }

        public void UpdatePartiallyByVin(int Vin, JsonPatchDocument<CarDTO> pathDTO)
        {
            if (Vin < 0)
            {

                CarBadRequestException badRequestException = new()
                {
                    Cause = "InvalidVin",
                    Information = "Vin Must Not Be Below Zero !"

                };
                throw badRequestException;

                
            }

            var OldCar = _carRepository.GetByVinNoTracking(Vin);

            if (OldCar == null)
            {
                CarNotFoundException notFoundException = new()
                {
                    Cause = "VinNotFound",
                    Information = "Car with This VIN does not Exist !"

                };

                throw notFoundException;
            }


            var NewCar = _mapper.Map<CarDTO>(OldCar);

            
           

            pathDTO.ApplyTo(NewCar);


            var NewCarToDatabase = _mapper.Map<Car>(NewCar);
            NewCarToDatabase.UpdateDate = DateTime.Now;
            NewCarToDatabase.CreateDate = OldCar.CreateDate;
            NewCarToDatabase.Fuel = NewCarToDatabase.Fuel.ToLower();

            _carRepository.Update(NewCarToDatabase);

            _carRepository.Save();

            
            
        }


    }
}
