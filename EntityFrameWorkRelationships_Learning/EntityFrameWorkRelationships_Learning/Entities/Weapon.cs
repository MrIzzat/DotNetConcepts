using System.Text.Json.Serialization;

namespace EntityFrameWorkRelationships_Learning.Entities
{
    public class Weapon
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? CharacterId { get; set; }
        [JsonIgnore]
        public Character? Character { get; set; }


    }
}
