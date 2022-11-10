using System.Text.Json.Serialization;

namespace ScooterRental.Core.Models
{
    public class Scooter : Entity
    {
        [JsonIgnore]
        public bool IsRented { get; set; }
    }
}
