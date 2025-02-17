using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Models.DTO
{
    public class VillaDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Details { get; set; }

        public int Occupancy { get; set; }

        public double Rate { get; set; }
        [Required]

        public int Sqft { get; set; }

        public string ImageUrl { get; set; }

        public string Amenity { get; set; }


    }
}
