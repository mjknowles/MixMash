using MixMash.Shared.BL.Contracts;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MixMash.Shared.BL.ViewModels
{
    public class DefineSeedGenresViewModel 
        : MvxViewModel
    {
        private readonly ISpotifyClient _spotifyClient;

        public DefineSeedGenresViewModel(ISpotifyClient spotifyClient)
        {
            _spotifyClient = spotifyClient;
            var genres = _spotifyClient.GetGenres().Result;
            SeedGenres = genres.Select(g => new Genre_ListItem { Name = g }).ToList();
        }

        private IList<Genre_ListItem> _seedGenres;
        public IList<Genre_ListItem> SeedGenres
        { 
            get { return _seedGenres; }
            set { SetProperty (ref _seedGenres, value); }
        }
    }

    public class Genre_ListItem
    {
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
