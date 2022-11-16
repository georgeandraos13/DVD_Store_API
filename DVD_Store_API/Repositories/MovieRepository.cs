using DVD_Store_API.Data;
using DVD_Store_API.Interfaces;
using DVD_Store_API.Exceptions;
using DVD_Store_API.Models;

namespace DVD_Store_API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext datacontext;

        public MovieRepository(DataContext datacontext)
        {
            this.datacontext = datacontext;
        }
        public ICollection<Movie> GetMovies()
        {
            ICollection<Movie> moview = datacontext.Movies.OrderBy(x => x.Id).ToList();
            if (moview.Count <= 0)
                throw new ObjectNotFoundException();
            else
                return moview;
        }
        public bool Exists(int id)
        {
            return datacontext.Movies.Any(x => x.Id == id);
        }

        public bool Exists(string title)
        {
            return datacontext.Movies.Any(p => p.Title == title);
        }
        public Movie GetMovie(int id)
        {
            if (!Exists(id))
                throw new ObjectNotFoundException();
            else
            {
                Movie? m = datacontext.Movies.Where(p => p.Id == id).FirstOrDefault();
                if (m == null)
                    throw new ObjectNotFoundException();
                else
                    return m;
            }
        }
        public int GetMovieId(string title)
        {
            if (!Exists(title))
                throw new ObjectNotFoundException();
            else
            {
                Movie? m=datacontext.Movies.Where(p=>p.Title== title).FirstOrDefault();
                if (m == null)
                    throw new ObjectNotFoundException();
                else
                    return m.Id;
            }
        }
        public void AddMovie(Movie m)
        {
            if (Exists(m.Id))
                throw new ObjectAlreadyExistsException();
            else
            {
                datacontext.Movies.Add(m);
                datacontext.SaveChanges();
            }
        }
        public void DeleteMovie(Movie m)
        {
            if (!Exists(m.Id))
                throw new ObjectNotFoundException();
            else
            {
                datacontext.Movies.Remove(m);
                datacontext.SaveChanges();
            }
        }
        public void UpdateMovie(int id, Movie newmovie)
        {
            if (!Exists(id))
                throw new ObjectNotFoundException();
            else
            {
                Movie? m = datacontext.Movies.Where(p => p.Id == id).FirstOrDefault();
                if (m == null)
                    throw new ObjectNotFoundException();
                else
                {
                    m.Title = newmovie.Title;
                    datacontext.SaveChanges();
                }
            }
        }
    }
}
