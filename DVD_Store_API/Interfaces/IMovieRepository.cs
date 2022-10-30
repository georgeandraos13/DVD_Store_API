using DVD_Store_API.Models;

namespace DVD_Store_API.Interfaces
{
    public interface IMovieRepository
    {
        public ICollection<Movie> GetMovies();
        public int GetMovieId(string MovieTitle);
        public bool Exists(int id);
        public Movie GetMovie(int id);
        public void AddMovie(string Title);
        public void DeleteMovie(int id);
        public void UpdateMovie(int id, string NewTitle);
    }
}
