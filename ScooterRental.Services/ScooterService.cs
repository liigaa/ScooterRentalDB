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
    }
}
