using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!; // so that the warning about Name being nullable goes away
        //Can use the [Required] attribute to make sure null is not stored in the database but use a nullable reference with string?

        [Column(TypeName = "decimal(6,2)")]

        public decimal Price { get; set; }

    }
}
