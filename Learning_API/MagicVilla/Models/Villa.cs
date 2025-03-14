﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla.Models
{
    public class Villa
    {
        // need to install nuget packages for entity framework core
        // it's called entityframeworkcore.sqlserver
        // and entityframeworkcore.tools

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Details { get; set; }

        public double Rate { get; set; }

        public int Sqft { get; set; }

        public int Occupancy { get; set; }

        public string ImageUrl { get; set; }

        public string Amenity { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }


    }
}
