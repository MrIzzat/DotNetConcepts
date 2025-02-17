using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FluentAPIs.Entities
{
    public class Backpack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public int? CharacterId { get; set; }
        [JsonIgnore]
        public Character? Character { get; set; }
    }
}