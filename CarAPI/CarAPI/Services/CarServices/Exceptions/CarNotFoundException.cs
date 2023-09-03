namespace CarAPI.Services.CarServices.Exceptions
{
    public class CarNotFoundException : Exception
    {

        public string Cause { get; set; } = null!;
        public string Information { get; set; } = null!;
    }
}
