using System.ComponentModel.DataAnnotations;

namespace CarAPI.Models.DTO
{
    public class CarDTO
    {

        public int Id { get; set; }
        [Required]
        public int Vin { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int EngineSize { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]

        public bool HasTurbo { get; set; }
        [Required]
        public string Fuel { get; set; }
       

    }
}
