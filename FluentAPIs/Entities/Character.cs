using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FluentAPIs.Entities
{
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [JsonIgnore]

        public Backpack? Backpack { get; set; } 

        public List<Weapon>? Weapons { get; set; }

        public List<Faction>? Factions { get; set; }
    }
}
