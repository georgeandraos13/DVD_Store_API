namespace DVD_Store_API.Models
{
    public class ActorActress
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<MovieActorActress>? MoviesActorsActresses { get; set; }
    }
}
