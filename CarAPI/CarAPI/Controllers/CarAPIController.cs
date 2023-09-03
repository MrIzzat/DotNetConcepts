using Azure;
using CarAPI.DataAccess;
using CarAPI.Models;
using CarAPI.Models.DTO;
using CarAPI.Services.CarServices;
using CarAPI.Services.CarServices.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarAPI.Controllers
{
    [Route("api/Cars")]
    [ApiController]
    public class CarAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db; // Not very good causes API to be fat
        private readonly ILogger<CarAPIController> _logger;
        private readonly ICarService _carService;

        public CarAPIController(ILogger<CarAPIController> logger,ICarService carService) {

          //  _db = db;
            _logger = logger;
            _carService = carService;
        }



        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_carService.Get());
        }

        [HttpGet("GetById/{Id:int}", Name = "GetCar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_carService.GetById(Id));
            }
            catch (CarBadRequestException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return BadRequest(ModelState);
            }
            catch (CarNotFoundException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return NotFound(ModelState);
            }

        }

        [HttpGet("GetByVin/{Vin:int}", Name = "GetCarByVin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetCarByVin(int Vin)
        {
            try
            {
                return Ok(_carService.GetByVin(Vin));
            }
            catch (CarBadRequestException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return BadRequest(ModelState);
            }
            catch (CarNotFoundException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return NotFound(ModelState);
            }

        }

        [HttpPost("AddCar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCar([FromBody] CarDTO carDTO)
        {
            try
            {
                _carService.Add(carDTO);

                
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (CarBadRequestException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return BadRequest(ModelState);
            }
            catch (CarNotFoundException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return NotFound(ModelState);
            }


            


        }

        



        [HttpDelete("DeleteById/{Id:int}", Name = "DeleteCar")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteById(int Id)
        {
            try
            {
                _carService.DeleteById(Id);
                return NoContent();
            }
            catch (CarBadRequestException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return BadRequest(ModelState);
            }
            catch (CarNotFoundException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return NotFound(ModelState);
            }




        }


        [HttpDelete("DeleteByVin/{Vin:int}", Name = "DeleteCarByVin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteByVin(int Vin)
        {
            try
            {
                _carService.DeleteByVin(Vin);
                return NoContent();
            }
            catch (CarBadRequestException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return BadRequest(ModelState);
            }
            catch (CarNotFoundException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return NotFound(ModelState);
            }




        }



        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update([FromBody]CarDTO  carDTO)
        {

            try{
                 _carService.Update(carDTO);
                return NoContent();
            }
            catch (CarBadRequestException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return BadRequest(ModelState);
            }
            catch (CarNotFoundException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return NotFound(ModelState);
            }



        }


        [HttpPatch("UpdatePartiallyByVin/{Vin:int}",Name = "Update Partial Car By Vin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdatePartialByVin(int Vin, JsonPatchDocument<CarDTO> pathDTO )
        {

            try
            {
                _carService.UpdatePartiallyByVin(Vin, pathDTO);
                return NoContent();
            }
            catch (CarBadRequestException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return BadRequest(ModelState);
            }
            catch (CarNotFoundException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return NotFound(ModelState);
            }
        }


        [HttpPatch("UpdatePartiallyById/{Id:int}", Name = "Update Partial Car By Id")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult updatePartiallyById(int Id, JsonPatchDocument<CarDTO> pathDTO)
        {
            try
            {
                _carService.updatePartiallyById(Id, pathDTO);
                return NoContent();
            }
            catch (CarBadRequestException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return BadRequest(ModelState);
            }
            catch (CarNotFoundException ex)
            {
                ModelState.AddModelError(ex.Cause, ex.Information);
                return NotFound(ModelState);
            }

            




            return NoContent();
        }




    }
}
