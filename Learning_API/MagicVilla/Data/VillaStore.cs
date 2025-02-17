using MagicVilla.Models.DTO;

namespace MagicVilla.Data
{
    public class VillaStore
    {
        public static List<VillaDTO> VillaList =new List<VillaDTO>{

                new VillaDTO{Id=1,Name="Pool View",Sqft = 150,Occupancy = 2},
                new VillaDTO{Id=2, Name = "Beach View",Sqft = 200, Occupancy = 4}

            };

    }
}
