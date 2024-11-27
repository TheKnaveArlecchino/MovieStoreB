using Mapster;
using MovieStoreB.Models.DTO;
using MovieStoreB.Models.Request;

namespace MovieStoreB.Controllers.MapsterConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<AddMovieRequest, Movie>.NewConfig();
        }
    }
}
