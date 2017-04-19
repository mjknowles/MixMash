using MixMash.Shared.BL.Entities;
using MixMash.Shared.DAL;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MixMash.Shared.DL.Clients
{
    public interface ISqlLiteConnectionFactory
    {
        SQLiteAsyncConnection GetAsyncConnection();
        SQLiteConnection GetConnection();
    }

    public class SqlLiteService : ISqlLiteService
    {
        private static readonly AsyncLock Mutex = new AsyncLock();
        private readonly SQLiteAsyncConnection _asyncConnection;

        public SqlLiteService(ISqlLiteConnectionFactory connFactory)
        {
            var connection = connFactory.GetConnection();
            //connection.CreateTable<Track>();
            connection.CreateTable<Genre>();

            _asyncConnection = connFactory.GetAsyncConnection();
        }

        public async Task<List<Track>> GetRecommendedTracksAsync()
        {
            List<Track> conferences = new List<Track>();
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                conferences = await _asyncConnection.Table<Track>().ToListAsync().ConfigureAwait(false);
            }

            return conferences;
        }

        public async Task<List<Genre>> GetGenresAsync()
        {
            var genres = new List<Genre>();
            if (_asyncConnection != null)
            {
                genres = await _asyncConnection.Table<Genre>().ToListAsync();
            }
            return genres;
        }

        public async Task Save(Track track)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                var existingConference = await _asyncConnection.Table<Track>()
                        .Where(x => x.SpotifyId == track.SpotifyId)
                        .FirstOrDefaultAsync();

                if (existingConference == null)
                {
                    await _asyncConnection.InsertAsync(track).ConfigureAwait(false);
                }
                else {
                    track.Id = existingConference.Id;
                    await _asyncConnection.UpdateAsync(track).ConfigureAwait(false);
                }
            }
        }

        public async Task Save(Genre genre)
        {
            var existingGenre = await _asyncConnection.Table<Genre>()
                    .Where(x => x.Name == genre.Name)
                    .FirstOrDefaultAsync();

            if (existingGenre == null)
            {
                await _asyncConnection.InsertAsync(genre);
            }
            else
            {
                genre.Id = existingGenre.Id;
                await _asyncConnection.UpdateAsync(genre);
            }
        }

        public async Task SaveAll(IEnumerable<Track> tracks)
        {
            foreach (var track in tracks)
            {
                await Save(track);
            }
        }

        public async Task SaveAll(IEnumerable<Genre> genres)
        {
            foreach (var genre in genres)
            {
                await Save(genre);
            }
        }
    }
}
