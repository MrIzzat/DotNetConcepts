namespace CarAPI.Services.CarServices.Exceptions
{
    public class CarBadRequestException : Exception
    {

        public string Cause { get; set; } = null!;

        public string Information { get; set; } = null!;
    }
}
