using MixMash.Shared.BL.Contracts;
using MixMash.Shared.BL.Entities;
using MixMash.Shared.BL.ViewModelParameters;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MixMash.Shared.BL.ViewModels
{
    public class GenreSelectorViewModel 
        : MvxViewModel
    {
        private readonly ISpotifyClient _spotifyClient;

        public GenreSelectorViewModel(ISpotifyClient spotifyClient)
        {
            _spotifyClient = spotifyClient;
            var genres = _spotifyClient.GetGenres().Result;
            SeedGenres = genres.Select(g => new Genre_ListItem(g)).ToList();
            CreatePlaylistText = "Get Playlist!";
        }

        private IList<Genre_ListItem> _seedGenres;
        public IList<Genre_ListItem> SeedGenres
        { 
            get { return _seedGenres; }
            set { SetProperty (ref _seedGenres, value); }
        }


        private string _createPlaylistText;
        public string CreatePlaylistText
        {
            get { return _createPlaylistText; }
            private set { SetProperty(ref _createPlaylistText, value); }
        }

        public ICommand CreatePlaylistCommand
        { 
            get
            {
                return new MvxCommand(() => ShowViewModel<TuneableAttribsSelectorViewModel>(new TuneableAttribsParams()));
            }
        }
    }

    public class Genre_ListItem : MvxViewModel
    {
        public Genre_ListItem(string name)
        {
            Name = name;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            private set { SetProperty(ref _name, value); }
        }

        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }

        public ICommand ItemSelectedCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Selected = !Selected;
                });
            }
        }
    }
}
