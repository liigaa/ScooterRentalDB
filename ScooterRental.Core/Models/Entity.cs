namespace ScooterRental.Core.Models
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public decimal PricePerMinute { get; set; }

        protected Entity(string id, decimal pricePerMinute)
        {
            Id = id;
            PricePerMinute = pricePerMinute;
        }

    }
}
