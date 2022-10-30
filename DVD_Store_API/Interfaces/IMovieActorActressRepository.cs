using DVD_Store_API.Models;

namespace DVD_Store_API.Interfaces
{
    public interface IMovieActorActressRepository
    {
        public ICollection<MovieActorActress> GetAll();
        public ICollection<MovieActorActress> GetByActorActress(int actorActressId);
        public ICollection<MovieActorActress> GetByMovie(int movieId);
        public MovieActorActress GetById(int id);
        public void AddMovieActorActress(MovieActorActress movieActorActress);
        public void DeleteMovieActorActress(MovieActorActress movieActorActress);
        public void UpdateMovieActorActress(int id, MovieActorActress newMovieActorActress);
    }
}
