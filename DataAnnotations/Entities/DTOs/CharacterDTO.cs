namespace DataAnnotations.Entities.DTOs
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public BackpackDTO? Backpack { get; set; }

        public List<WeaponDTO>? Weapons { get; set; }

        public List<FactionDTO>? Factions { get; set; } 
    }
}
