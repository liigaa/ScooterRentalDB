using ScooterRental.Core.Models;

namespace ScooterRental.Core.Validations
{
    public class IdValidator : IScooterValidator
    {
        public bool IsValid(Scooter scooter)
        {
            return !string.IsNullOrEmpty(scooter.Id);
        }
    }
}
