using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ScooterRental.Core.Models;

namespace ScooterRental.Data
{
    public interface IScooterRentalDbContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<Scooter> Scooters { get; set; }
        DbSet<RentedScooter> RentedScooters { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
