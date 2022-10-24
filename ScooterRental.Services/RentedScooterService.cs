using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScooterRental.Core;
using ScooterRental.Core.Models;
using ScooterRental.Core.Services;
using ScooterRental.Data;

namespace ScooterRental.Services
{
    public class RentedScooterService : EntityService<RentedScooter>, IRentedScooterService
    {
        private readonly IIncomeCalculation _calculation;
        private readonly IScooterService _scooter;
        public RentedScooterService(IScooterRentalDbContext context) : base(context)
        {
            _calculation = new IncomeCalculation();
            _scooter = new ScooterService(context);
        }
        
        public void StartRent(Scooter scooter)
        {
            _scooter.UpdateScooterIsRentedToTrue(scooter);
            var rentedScooter = new RentedScooter(scooter.Id, DateTime.UtcNow, scooter.PricePerMinute);
            Create(rentedScooter);
        }

        public RentedScooter GetRentedScooter(string id)
        {
            return _context.RentedScooters.FirstOrDefault(scooter => scooter.Id == id && scooter.EndTime == null);
        }

        public void EndRent(RentedScooter scooter)
        {
            scooter.EndTime = DateTime.UtcNow;
            var totalPrice = _calculation.GetRentedScooterFee(scooter);
            scooter.TotalPrice = totalPrice;
            Update(scooter);
        }

        public decimal GetAllFinishedRentedSum()
        {
            return _context.RentedScooters.Where(scooter => scooter.EndTime.HasValue)
                .Sum(scooter => scooter.TotalPrice);
        }

        public decimal GetNotFinishedRentalIncome(int? year)
        {
            if (year != DateTime.UtcNow.Year && year.HasValue) return 0;

            var newList = _context.RentedScooters.Where(scooter => !scooter.EndTime.HasValue);

            var totalIncome = 0m;

            foreach (var scooter in newList)
            {
                scooter.EndTime = DateTime.UtcNow;
                totalIncome += _calculation.GetRentedScooterFee(scooter);
            }

            return totalIncome;
        }
    }
}
