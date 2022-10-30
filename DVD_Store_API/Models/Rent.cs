using System.Text.Json.Serialization;

namespace DVD_Store_API.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }
        public int MovidId { get; set; }
        [JsonIgnore]
        public Movie? Movie { get; set; }
        public DateTime RentDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; } = new DateTime(1900, 1, 1);
        public bool Deleted { get; set; }
    }
}
