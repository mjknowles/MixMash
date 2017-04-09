using AutoMapper;
using MixMash.Shared.BL.Entities;
using MixMash.Shared.BL.ValueObjects;
using MixMash.Shared.BL.ViewModelParameters;
using MixMash.Shared.DAL.Clients;
using MixMash.Shared.DL.Clients;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.ViewModels
{
    public class TracksViewModel : MvxViewModel
    {
        //private readonly SQLiteClient _db;
        private SpotifyRequestParams _spotifyRequestParams;

        private IList<TrackViewModel> _tracks;
        public IList<TrackViewModel> Tracks
        {
            get { return _tracks; }
            set { SetProperty(ref _tracks, value); }
        }

        public void Init(TracksParameters trackParams)
        {
            _spotifyRequestParams = new SpotifyRequestParams()
            {
                MinDanceability = trackParams.MinDanceability,
                MaxDanceability = trackParams.MaxDanceability
            };
        }

        public override async void Start()
        {
            base.Start();
            Tracks = Mapper.Map<IList<TrackViewModel>>(await GetRecommendedTracks());
        }

        public async Task<List<Track>> GetRecommendedTracks()
        {
            //await GetLocalRecommendedTracks();
            return await GetRemoteRecommendedTracks();
            //await GetLocalRecommendedTracks();
        }

        /*private async Task GetLocalRecommendedTracks()
        {
            Tracks = await _db.GetRecommendedTracksAsync();
        }*/

        private async Task<List<Track>> GetRemoteRecommendedTracks()
        {
            var remoteClient = new SpotifyService();
            return await remoteClient.GetRecommendedTracks(_spotifyRequestParams);
        }
    }
}
