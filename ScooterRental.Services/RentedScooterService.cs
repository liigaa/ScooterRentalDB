using System;
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
            //Validator.ScooterIdValidation(id);
            //Validator.ScooterAlreadyRentedValidation(id, _service);

            var rentedScooter = new RentedScooter(scooter.Id, DateTime.UtcNow, scooter.PricePerMinute);

            Create(rentedScooter);
        }
    }
}
