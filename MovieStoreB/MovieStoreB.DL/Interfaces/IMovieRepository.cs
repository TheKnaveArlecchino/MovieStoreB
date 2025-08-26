
using MovieStoreB.DL.Cache;
using MovieStoreB.Models.DTO;

namespace MovieStoreB.DL.Interfaces
{
    public interface IMovieRepository : ICacheRepository<string, Movie>
    {
        Task<List<Movie>> GetMovies();

        void AddMovieAsync(Movie movie);

        void DeleteMovieAsync(string id);

        Movie? GetMoviesByIdAsync(string id);
    }
}
