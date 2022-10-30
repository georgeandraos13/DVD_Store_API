using System.Text.Json.Serialization;

namespace DVD_Store_API.Models
{
    public class MovieActorActress
    {
        public int Id { get; set; }
        public int MovidId { get; set; }
        [JsonIgnore]
        public Movie? Movie { get; set; }
        public int ActorActressId { get; set; }
        [JsonIgnore]
        public ActorActress? ActorActress { get; set; }
    }
}
