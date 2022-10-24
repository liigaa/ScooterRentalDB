using ScooterRental.Core.Models;

namespace ScooterRental.Core.Services
{
    public interface IRentedScooterService : IEntityService<RentedScooter>
    {
        void StartRent(Scooter scooter);
        void EndRent(RentedScooter scooter);
        RentedScooter GetRentedScooter(string id);
        decimal GetAllFinishedRentedSum();
        decimal GetNotFinishedRentalIncome(int? year);
    }
}
