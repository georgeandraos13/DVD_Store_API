using DVD_Store_API.Models;

namespace DVD_Store_API.Interfaces
{
    public interface IMovieRepository
    {
        public ICollection<Movie> GetMovies();
        public int GetMovieId(string MovieTitle);
        public bool Exists(int id);
        public bool Exists(string Title);
        public Movie GetMovie(int id);
        public void AddMovie(Movie m);
        public void DeleteMovie(Movie m);
        public void UpdateMovie(int id, Movie newmovie);
    }
}
