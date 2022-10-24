using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ScooterRental.Core.Models
{
    public abstract class Entity
    {
        [Key]
        [JsonIgnore]
        public int PKey { get; set; }
        public string Id { get; set; }
        public decimal PricePerMinute { get; set; }

        protected Entity(string id, decimal pricePerMinute)
        {
            Id = id;
            PricePerMinute = pricePerMinute;
        }

        protected Entity()
        {
        }
    }
}
