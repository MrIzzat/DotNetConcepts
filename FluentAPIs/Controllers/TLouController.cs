using FluentAPIs.Data;
using FluentAPIs.Entities;
using FluentAPIs.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FluentAPIs.Controllers
{

    [Route("api/Tlou")]
    [ApiController]
    public class TLouController :ControllerBase
    {

        private readonly ApplicationDbContext _db;

        public TLouController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterDTO request)
        {
            var newCharacter = new Character
            {
                Name = request.Name,
            };

            if (request.Backpack != null)
            {
                var backpack = new Backpack
                {
                    Description = request.Backpack.Description,
                    Character = newCharacter
                };
                newCharacter.Backpack = backpack;
            }
            if(request.Weapons != null)
            {
                var weapons = request.Weapons.Select(w => new Weapon { Name = w.Name, Character = newCharacter }).ToList();
                newCharacter.Weapons = weapons;
            }

            if(request.Factions  != null)
            {
                var factions = request.Factions.Select(f => new Faction { Name = f.Name, Characters = new List<Character>() { newCharacter } }).ToList();
                newCharacter.Factions = factions;
            }
            
            

            _db.Characters.Add(newCharacter);

            await _db.SaveChangesAsync();

            return Ok(await _db.Characters.Include(c => c.Backpack).Include(c => c.Weapons).ToListAsync());
        
        
        }

        [HttpGet("GetById/{Id:int}")]
        public async Task<ActionResult<Character>> GetCharacterById(int Id)
        {
            var character = await _db.Characters.Include(c => c.Backpack).Include(c => c.Weapons).Include(c => c.Factions).FirstOrDefaultAsync(c => c.Id == Id);


            if(character == null)
            {
                return NotFound(character);
            }

            return Ok(character);

        }


        



    }
}
