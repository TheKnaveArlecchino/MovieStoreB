using MovieStoreC.Models.DTO;

namespace MovieStoreC.DL.Interfaces
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetAllAsync();

        Task<List<Actor>> GetAllAsync(List<string> ids);

        Task<Actor?> GetByIdAsync(string id);

        Task AddAsync(Actor? actor);

        Task UpdateAsync(Actor movie);
    }
}
