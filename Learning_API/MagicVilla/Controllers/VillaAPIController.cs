using MagicVilla.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MagicVilla.Logging;
using MagicVilla.Models.DTO;
using MagicVilla.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Controllers
{
    [Route("api/VillaAPI")]// can be called "api/[controller]"
    [ApiController] // will need to  enforece required or max length manually without this
    public class VillaAPIController : ControllerBase
    {
        /*        private readonly ILogging _logger; //Custom Logger

                public VillaAPIController(ILogging logger)
                {
                    _logger = logger;
                }
        */
        /*        private readonly ILogger<VillaAPIController> _logger;

                public VillaAPIController(ILogger<VillaAPIController> logger)
                {
                    // _logger = logger;
                    // install serilog aspnetcore to be able to store logs into files
                }*/


        private readonly ApplicationDbContext _db;
        public  VillaAPIController(ApplicationDbContext db)
        {
            _db = db;
        }




        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> getVIllas()
        {
//            _logger.Log("Getting All Villas","");
            //return Ok(VillaStore.VillaList);// from villastore staic data
            return Ok(_db.Villa.ToList());//Gets all Villas from database
        }

        [HttpGet("{Id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        /*  [ProducesResponseType(200, Type = typeof(VillaDTO))]
          [ProducesResponseType(404)]
          [ProducesResponseType(400)]*/
        public ActionResult<VillaDTO> getVIlla(int Id)
        {
            if (Id == 0)
            {
//                _logger.Log("Tried Get Villa Error with Id " + Id,"error");
                return BadRequest();
            }
            //var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == Id);
            var villa = _db.Villa.FirstOrDefault(x => x.Id == Id);//writes the sql to retrieve the villa with that ID
            if (villa == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status201Created, villa);
            // return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO) //state validation is done before reaching the first line in the method
        {/*
            if(!ModelState.IsValid) // Manually checks if it applies conditions in VillaDTO model fil
                                    // hover over Model State in debug mode to see what the exact error is
                                    // then expand > Results View > open [0] > value > Non-Public Members
                                    // > errors > [0] > error message
                return BadRequest(ModelState);*/
            //VillaStore.VillaList.
            if (_db.Villa.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("VillaNameDuplication", "Villa Alerady Exists!");//Creates custom error message
                return BadRequest(ModelState);
            }
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            /* villaDTO.Id = VillaStore.VillaList.OrderByDescending(u => u.Id)
                 .FirstOrDefault().Id + 1; // Sorts the villa list in descending order based on the ID 
                                          //and returns the largest and +1

             VillaStore.VillaList.Add(villaDTO);*/ //Is not needed with EntityFrameorkCore

            Villa NewVilla = new Villa()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft
            };


            _db.Villa.Add(NewVilla);//Saves the data to a list to be added to the database
            _db.SaveChanges();//Will this will push data to the databse




            // was return Ok(villaDTO);
            return CreatedAtRoute("GetVilla", new { Id = villaDTO.Id }, villaDTO);
            //The location of the API object can be found in the location section in
            // the Response Header
        }

        [HttpDelete("{Id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVilla(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            // var villa = VillaStore.VillaList.FirstOrDefault(v => v.Id == Id);
            var villa = _db.Villa.FirstOrDefault(v => v.Id == Id);
            if (villa == null)
            {
                return NotFound();
            }
            //VillaStore.VillaList.Remove(villa);
            _db.Villa.Remove(villa);
            _db.SaveChanges();//Need it for delete too 


            return NoContent();// can use Ok() but when deleting it's best to return NoContent which is 204
        }

        [HttpPut("{Id:int}", Name = "Update Villa")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateVilla(int Id, [FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null || Id != villaDTO.Id)
            {
                return BadRequest();
            }

            /*            var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == Id);

                        villa.Name = villaDTO.Name;
                        villa.Occupancy = villaDTO.Occupancy;
                        villa.Sqft = villaDTO.Sqft;*/ //Not needed with entityframeworkcore

            Villa NewVilla = new ()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft
            };

            _db.Villa.Update(NewVilla);
            _db.SaveChanges();


            return NoContent();

        }

        [HttpPatch("{Id:int}", Name = "Update Partial Villa ")]// check JSON Patch on google
        // to see methods that can be used
        // To add patch support some nuget packages must be added
        // Right Click Project -> Manage NuGet packages -> Install Microsoft JsonPatch
        // Also Install Micrsoft NewtonSoftJson
        // Make Sure the Versions are the same
        //builder.Services.AddControllers().AddNewtonsoftJson() add the last method in Pogram.cs
        //Patch updates a singular value of the object
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdatePartialVilla(int Id, JsonPatchDocument<VillaDTO> patchDTO)
        {//There's a way to do patch with stored procedure
            if (patchDTO == null || Id == 0)
            {
                return BadRequest();
            }

           // var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == Id);

           // var villa = _db.Villa.FirstOrDefault(u => u.Id == Id);
            var villa = _db.Villa.AsNoTracking().FirstOrDefault(u => u.Id == Id);

            if (villa == null)
            {
                return BadRequest();
            }

            VillaDTO NewVilla = new ()
            {
                Amenity = villa.Amenity,
                Details = villa.Details,
                Id = villa.Id,
                ImageUrl = villa.ImageUrl,
                Name = villa.Name,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Sqft = villa.Sqft
            };

            patchDTO.ApplyTo(NewVilla,ModelState);

            Villa model = new()
            {
                Amenity = NewVilla.Amenity,
                Details = NewVilla.Details,
                Id = NewVilla.Id,
                ImageUrl = NewVilla.ImageUrl,
                Name = NewVilla.Name,
                Occupancy = NewVilla.Occupancy,
                Rate = NewVilla.Rate,
                Sqft = NewVilla.Sqft

            };

            _db.Villa.Update(model);
            _db.SaveChanges();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();

        }





    }
}
