namespace AutoMapping.Entities
{
    public class SuperHero
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Place { get; set; } = null!;

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
