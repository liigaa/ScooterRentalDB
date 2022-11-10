using System;

namespace ScooterRental.Core.Models
{
    public class RentedScooter : Entity
    {
        public DateTime StarTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal TotalPrice { get; set; }

        public RentedScooter(string id, DateTime starTime, decimal pricePerMinute) : base(id, pricePerMinute)
        {
            StarTime = starTime;
            PricePerMinute = pricePerMinute;
            TotalPrice = 0;
        }
        public RentedScooter(string id, DateTime starTime, DateTime endTime, decimal pricePerMinute) : base(id, pricePerMinute)
        {
            StarTime = starTime;
            EndTime = endTime;
            PricePerMinute = pricePerMinute;
            TotalPrice = 0;
        }
    }
}
