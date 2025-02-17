namespace FluentAPIs.Entities
{
    public class Faction
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Character>? Characters { get; set; }
    }
}
