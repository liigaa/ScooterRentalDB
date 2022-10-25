using ScooterRental.Core.Models;

namespace ScooterRental.Core
{
    public interface IRentCalculation
    {
        public decimal GetRentedScooterFee(RentedScooter scooter);
    }
}
