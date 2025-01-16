using MovieStoreB.BL.Interfaces;
using MovieStoreB.DL.Interfaces;
using MovieStoreB.Models.DTO;

namespace MovieStoreB.BL.Services
{
    internal class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;

        public MovieService(IMovieService @object, IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetMovies()
        {
            return _movieRepository.GetMovies();
        }

        public void AddMovie(Movie movie)
        {
            if (movie == null || movie.Actors == null) return;

            foreach (var actor in movie.Actors)
            {
                if (!Guid.TryParse(actor, out _)) return;
            }

            _movieRepository.AddMovie(movie);
        }

        public void DeleteMovie(string id)
        {
            if (string.IsNullOrEmpty(id)) return;

            _movieRepository.DeleteMovie(id);
        }

        public Movie? GetMoviesById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return null;
            }

            return _movieRepository.GetMoviesById(id);
        }
        public void AddActor(string movieId, Actor actor)
        {
            if (string.IsNullOrEmpty(movieId)  || actor == null) return;

            if (!Guid.TryParse(movieId, out _)) return;

            var movie = _movieRepository.GetMoviesById(movieId);

            if (movie == null) return;

            if (movie.Actors == null)
            {
                movie.Actors = new List<string>();
            }

            if (actor.Id == null || string.IsNullOrEmpty(actor.Id) || !Guid.TryParse(actor.Id, out _)) return;

            _actorRepository.GetById(actor.Id);

            movie.Actors.Add(actor.Id);
        }

    }
}
