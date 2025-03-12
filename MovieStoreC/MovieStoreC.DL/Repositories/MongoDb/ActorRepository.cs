using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieStoreC.DL.Interfaces;
using MovieStoreC.Models.Configurations;
using MovieStoreC.Models.DTO;

namespace MovieStoreC.DL.Repositories.MongoDb
{
    internal class ActorRepository : IActorRepository
    {
        private readonly IMongoCollection<Actor> _actorsCollection;
        private readonly ILogger<ActorRepository> _logger;

        public ActorRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<ActorRepository> logger)
        {
            _logger = logger;

            var client =
                new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);
            _actorsCollection = database.GetCollection<Actor>("ActorsDb");
        }
        
        public async Task<List<Actor>> GetAllAsync()
        {
            var result = await _actorsCollection.FindAsync(m => true);

            return await result.ToListAsync();
        }

        public async Task<Actor?> GetAllAsync(string id)
        {
            var result = await _actorsCollection
                .FindAsync(m => m.Id == id);

             return await result.FirstOrDefaultAsync();
        }

        public async Task GetAllAsync(Actor? actor)
        {
            if (actor == null)
            {
                _logger.LogError("Movie is null");

                return;
            }

            try
            {
                await _actorsCollection.InsertOneAsync(actor);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to add movie");
            }
        }

        public async Task UpdateAsync(Actor movie)
        {
            await _actorsCollection.ReplaceOneAsync(m => m.Id == movie.Id, movie);
        }

        public async Task<List<Actor>> GetAllAsync(List<string> ids)
        {
            if (ids == null || !ids.Any()) return [];

            var result = await _actorsCollection.FindAsync(m => ids.Contains(m.Id));

            return await result.ToListAsync();
        }

        public Task<Actor?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Actor? actor)
        {
            throw new NotImplementedException();
        }
    }
}
