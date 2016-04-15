using MixMash.Shared.BL.Entities;
using MixMash.Shared.DAL;
using SQLite.Net.Async;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MixMash.Shared.DL.Clients
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }

    public class SQLiteClient
    {
        private static readonly AsyncLock Mutex = new AsyncLock();
        private readonly SQLiteAsyncConnection _connection;

        public SQLiteClient(ISQLite sql)
        {
            _connection = sql.GetConnection();
            CreateDatabaseAsync();
        }

        public async Task CreateDatabaseAsync()
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                await _connection.CreateTableAsync<Track>().ConfigureAwait(false);
            }
        }

        public async Task<List<Track>> GetRecommendedTracksAsync()
        {
            List<Track> conferences = new List<Track>();
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                conferences = await _connection.Table<Track>().ToListAsync().ConfigureAwait(false);
            }

            return conferences;
        }

        public async Task Save(Track track)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                // Because our conference model is being mapped from the dto,
                // we need to check the database by name, not id
                var existingConference = await _connection.Table<Track>()
                        .Where(x => x.SpotifyId == track.SpotifyId)
                        .FirstOrDefaultAsync();

                if (existingConference == null)
                {
                    await _connection.InsertAsync(track).ConfigureAwait(false);
                }
                else {
                    track.Id = existingConference.Id;
                    await _connection.UpdateAsync(track).ConfigureAwait(false);
                }
            }
        }

        public async Task SaveAll(IEnumerable<Track> tracks)
        {
            foreach (var track in tracks)
            {
                await Save(track);
            }
        }
    }
}
