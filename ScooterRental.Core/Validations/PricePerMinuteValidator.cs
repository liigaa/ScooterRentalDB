using ScooterRental.Core.Models;

namespace ScooterRental.Core.Validations
{
    public class PricePerMinuteValidator : IScooterValidator
    {
        public bool IsValid(Scooter scooter)
        {
            return scooter.PricePerMinute >= 0;
        }
    }
}
