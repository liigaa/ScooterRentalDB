using System;
using System.Linq;
using ScooterRental.Core;
using ScooterRental.Core.Models;
using ScooterRental.Core.Services;
using ScooterRental.Data;

namespace ScooterRental.Services
{
    public class RentedScooterService : EntityService<RentedScooter>, IRentedScooterService
    {
        public RentedScooterService(IScooterRentalDbContext context) : base(context)
        {
        }

        public void StartRent(Scooter scooter)
        {
            var rentedScooter = new RentedScooter(scooter.Id, DateTime.UtcNow, scooter.PricePerMinute);

            Create(rentedScooter);
        }

        public RentedScooter GetRentedScooter(string id)
        {
            return _context.RentedScooters.FirstOrDefault(scooter => scooter.Id == id && scooter.EndTime == null);
        }

        //public void EndRent(RentedScooter scooter)
        //{
        //    scooter.EndTime = DateTime.UtcNow;
        //    var totalPrice = _calculation.GetRentedScooterFee(scooter);
        //    scooter.TotalPrice = totalPrice;
        //    Update(scooter);
        //}
    }
}
