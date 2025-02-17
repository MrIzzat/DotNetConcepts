using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAnnotations.Entities
{
    [Table("Character",Schema = "dbo")]// aparently there  aren't any more things I can do with this annotation.
    //First one is used for the name the second one is for the schema
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        [MinLength(3)]
        public string Name { get; set; } = null!;
        [JsonIgnore]

        public Backpack? Backpack { get; set; } 

        public List<Weapon>? Weapons { get; set; }

        public List<Faction>? Factions { get; set; }
    }
}
