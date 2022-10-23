using ScooterRental.Core.Models;

namespace ScooterRental.Core.Services
{
    public interface IRentedScooterService : IEntityService<RentedScooter>
    {
        void StartRent(Scooter scooter);
    }
}
