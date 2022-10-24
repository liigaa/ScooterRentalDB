using ScooterRental.Core.Models;

namespace ScooterRental.Core.Validations
{
    public interface IScooterValidator
    {
        bool IsValid(Scooter scooter);
    }
}
