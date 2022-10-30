namespace DVD_Store_API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<MovieActorActress>? MoviesActorsActresses { get; set; }
        public ICollection<Rent>? Rents { get; set; }
    }
}
