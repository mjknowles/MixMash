using AutoMapper;
using MixMash.Shared.BL.Entities;
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
        //private readonly IMapper _mapper;
        //private readonly SQLiteClient _db;

        private IList<TrackViewModel> _tracks;
        public IList<TrackViewModel> Tracks
        {
            get { return _tracks; }
            set { SetProperty(ref _tracks, value); }
        }

        /*public TracksViewModel(IMapper mapper, ISQLite sql)
        {
            _mapper = mapper;
            _db = new SQLiteClient(sql);
        }*/

        public void Init(TracksParameters trackParams)
        {
            Tracks = trackParams.Tracks;
        }

        /*public async Task GetRecommendedTracks()
        {
            await GetLocalRecommendedTracks();
            await GetRemoteRecommendedTracks();
            await GetLocalRecommendedTracks();
        }

        private async Task GetLocalRecommendedTracks()
        {
            RecommendedTracks = await _db.GetRecommendedTracksAsync();
        }

        private async Task GetRemoteRecommendedTracks()
        {
            var remoteClient = new SpotifyClient(_mapper);
            var tracks = await remoteClient.GetRecommendedTracks().ConfigureAwait(false);
            await _db.SaveAll(tracks).ConfigureAwait(false);
        }*/
    }
}
