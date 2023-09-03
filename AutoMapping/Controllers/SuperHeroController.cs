using AutoMapper;
using AutoMapping.Data;
using AutoMapping.Entities;
using AutoMapping.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapping.Controllers
{

    [Route("api/SuperHeroes")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        //To install automapper libarary
        //Go to Nuget packages
        //Install AutoMapper.Extensions.Microsoft.DependencyInjection
        //Add it to servies in the program.cs file


        private readonly ILogger<SuperHeroController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;//Inject this mapper object into the controller

        public SuperHeroController(ILogger<SuperHeroController> logger,ApplicationDbContext db,IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }


        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_db.SuperHeroes.Select(hero => _mapper.Map<SuperHeroDTO>(hero)));//syntax for the mapping but it needs some mapping configuration before it can be used
            //we do that by creating a profile
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add([FromBody] SuperHeroDTO superHeroDTO)
        {
            var hero = _mapper.Map<SuperHero>(superHeroDTO);
            _db.SuperHeroes.Add(hero);
            _db.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }



    }
}
