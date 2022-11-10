using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScooterRental.Core.Models;

namespace ScooterRental.Data
{
    public class ScooterRentalDbContext : DbContext, IScooterRentalDbContext
    {
        public ScooterRentalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Scooter> Scooters { get; set; }
        public DbSet<RentedScooter> RentedScooters { get; set; }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
