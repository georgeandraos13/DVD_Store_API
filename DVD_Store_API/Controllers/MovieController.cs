using DVD_Store_API.Exceptions;
using DVD_Store_API.Interfaces;
using DVD_Store_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DVD_Store_API.Controllers
{
    [Route("api/controllers")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpPost]
        [Route("/movie/add/title")]
        public ActionResult<Movie> AddMovie(string title)
        {
            try
            {
                Movie m = new Movie();
                m.Title = title;

                movieRepository.AddMovie(m);

                return Ok(m);
            }
            catch (ObjectAlreadyExistsException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("/movie/del/title")]

        public ActionResult DeleteMovie(string title)
        {
            try
            {
                int id = movieRepository.GetMovieId(title);
                Movie m=new Movie();
                m.Id = id;
                m.Title = title;

                movieRepository.DeleteMovie(m);
                return Ok();
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("/movie/upd/id/newmovie")]

        public ActionResult UpdateMovie(int id, Movie newmovie)
        {
            try
            {
                movieRepository.UpdateMovie(id, newmovie);

                return Ok(newmovie);
            }
            catch (ObjectNotFoundException)
            {
                return NotFound(id);
            }
            catch (Exception)
            {
                return BadRequest(id);
            }
        }

        [HttpGet]
        [Route("/movie/get/all")]

        public ActionResult<ICollection<Movie>> GetMovies()
        {
            try
            {
                ICollection<Movie> movies = movieRepository.GetMovies();
                return Ok(movies);
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/movie/get/id")]

        public ActionResult<Movie> GetMovie(int id)
        {
            try
            {
                Movie movie = movieRepository.GetMovie(id);
                return Ok(movie);
            }
            catch (ObjectNotFoundException)
            {
                return NotFound(id);
            }
            catch (Exception)
            {
                return BadRequest(id);
            }
        }
    }
}
