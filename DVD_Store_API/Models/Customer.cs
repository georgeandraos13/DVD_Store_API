namespace DVD_Store_API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? JoinedDate { get; set; }
        public ICollection<Rent>? Rents { get; set; }
    }
}
