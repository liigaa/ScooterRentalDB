using ScooterRental.Core.Models;
using System.Collections.Generic;

namespace ScooterRental.Core.Services
{
    public interface IScooterService : IEntityService<Scooter>
    {
        bool ScooterExists(string id);
        List<Scooter> GetAvailableScooters();
    }
}
