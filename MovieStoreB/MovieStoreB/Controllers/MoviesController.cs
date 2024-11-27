using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreB.BL.Interfaces;
using MovieStoreB.Models.DTO;
using MovieStoreB.Models.Request;

namespace MovieStoreB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        private readonly ILogger<MoviesController> _logger;
  

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;        
        }

        [HttpGet("GetAll")]
        public IEnumerable<Movie> GetAll()

        {
            return _movieService.GetMovies();
        }




        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result =
                _movieService.GetMoviesById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("AddMovie")]
        public void AddMovie(
            [FromBody]AddMovieRequest movieRequest)
        {
            var movie = _mapper.Map<Movie>(movieRequest);
            _movieService.AddMovie(movie);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest($"Wrong id:{id}");

            _movieService.DeleteMovie(id);

            return Ok();
        }
    }
}
