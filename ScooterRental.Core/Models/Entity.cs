namespace ScooterRental.Core.Models
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public decimal PricePerMinute { get; set; }

        //public Entity(string id)
        //{
        //    Id = id;
        //}

    }
}
