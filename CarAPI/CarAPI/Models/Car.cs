using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAPI.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Vin { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int EngineSize { get; set; }
        public double Price { get; set; }
            
        public bool HasTurbo { get; set; }
        public string Fuel { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }



    }
}
