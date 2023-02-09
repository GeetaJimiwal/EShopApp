using Microsoft.AspNetCore.Mvc;
using MovieTicketApi.Repository.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        // GET: api/<CityController>
        [HttpGet]
        public IEnumerable<Model.Movie> Get()
        {
            var movies = movieRepository.GetAll();
            return movies;
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public List<Model.Movie> Get(int id)
        {
            var moviesById = new List<Model.Movie>();
            var movies = movieRepository.GetAll();
            foreach (var movie in movies)
            {
                if(movie.CityId == id)
                {
                    moviesById.Add(movie);
                }
            }
            return moviesById;
        }

        // POST api/<CityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
