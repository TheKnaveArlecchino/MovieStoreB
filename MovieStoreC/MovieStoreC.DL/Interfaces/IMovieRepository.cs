using MovieStoreC.Models.DTO;

namespace MovieStoreC.DL.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();

        Task<Movie?> GetByIdAsync(string id);

        Task AddAsync(Movie movie);

        Task UpdateAsync(Movie movie);
    }
}
