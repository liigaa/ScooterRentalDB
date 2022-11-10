using System.Collections.Generic;
using System.Linq;
using ScooterRental.Core.Models;
using ScooterRental.Core.Services;
using ScooterRental.Data;

namespace ScooterRental.Services
{
    public class ScooterService : EntityService<Scooter>, IScooterService
    {
        public ScooterService(IScooterRentalDbContext context) : base(context)
        {
        }

        public bool ScooterExists(string id)
        {
            return _context.Scooters.Any(scooter => scooter.Id == id);
        }

        public List<Scooter> GetAvailableScooters()
        {
            return _context.Scooters.Where(scooter => scooter.IsRented == false).ToList();
        }

        public Scooter GetAvailableScooterById(string id)
        {
            return _context.Scooters.FirstOrDefault(scooter => scooter.Id == id && scooter.IsRented == false);
        }

        public Scooter GetRentedScooterById(string id)
        {
            return _context.Scooters.FirstOrDefault(scooter => scooter.Id == id && scooter.IsRented == true);
        }

        public void UpdateScooterIsRentedToTrue(Scooter scooter)
        {
            scooter.IsRented = true;

            Update(scooter);
        }

        public void UpdateScooterIsRentedToFalse(Scooter scooter)
        {
            scooter.IsRented = false;

            Update(scooter);
        }
    }
}
