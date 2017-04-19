using System.Collections.Generic;
using System.Threading.Tasks;
using MixMash.Shared.BL.Entities;

namespace MixMash.Shared.DL.Clients
{
    public interface ISqlLiteService
    {
        Task<List<Track>> GetRecommendedTracksAsync();
        Task<List<Genre>> GetGenresAsync();
        Task Save(Genre genre);
        Task Save(Track track);
        Task SaveAll(IEnumerable<Genre> genres);
        Task SaveAll(IEnumerable<Track> tracks);
    }
}