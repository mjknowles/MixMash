using AutoMapper;
using MixMash.Shared.BL.Contracts;
using MixMash.Shared.BL.Entities;
using MixMash.Shared.DL.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.DL.Repositories
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetCachedGenres();
        Task<List<Genre>> GetSpotifyGenres();
    }

    public class GenreRepository : IGenreRepository
    {
        private readonly ISpotifyService _spotifyService;
        private readonly ISqlLiteService _sqlLiteService;

        public GenreRepository(ISpotifyService spotifyService, ISqlLiteService sqlLiteService)
        {
            _spotifyService = spotifyService;
            _sqlLiteService = sqlLiteService;
        }

        public async Task<List<Genre>> GetCachedGenres()
        {
            return await _sqlLiteService.GetGenresAsync();
        }

        public async Task<List<Genre>> GetSpotifyGenres()
        {
            var genres = await _spotifyService.GetGenresAsync();
            var mapped = await Task.Run(() =>
                        Mapper.Map<List<Genre>>(genres)
                    ).ConfigureAwait(false);
            await _sqlLiteService.SaveAll(mapped);
            return mapped;
        }
    }
}
