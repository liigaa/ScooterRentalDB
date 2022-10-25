using ScooterRental.Core.Models;
using System;

namespace ScooterRental.Core
{
    public class RentCalculation : IRentCalculation
    {
        public decimal GetRentedScooterFee(RentedScooter scooter)
        {
            if (scooter.EndTime == null)
            {
                throw new Exception();
            }

            var startTime = scooter.StarTime;
            var endTime = (DateTime)scooter.EndTime;
            var days = endTime.Day - startTime.Day + 1;
            decimal totalPrice;

            if (days < 2)
            {
                TimeSpan time = endTime - startTime;
                var totalMinutes = Math.Ceiling(time.TotalMinutes);
                totalPrice = (decimal)totalMinutes * scooter.PricePerMinute;

                return totalPrice <= 20 ? totalPrice : 20;
            }

            var firsDayMinutes = 1440 - startTime.TimeOfDay.TotalMinutes;
            var price = (decimal)firsDayMinutes * scooter.PricePerMinute;
            var firstDayPrice = price <= 20 ? price : 20;

            var lastDayMinutes = endTime.TimeOfDay.TotalMinutes;
            var lastDPrice = (decimal)lastDayMinutes * scooter.PricePerMinute;
            var lastDayPrice = lastDPrice <= 20 ? price : 20;

            totalPrice = 20 * (days - 2) + firstDayPrice + lastDayPrice;

            return totalPrice;
        }
    }
}
