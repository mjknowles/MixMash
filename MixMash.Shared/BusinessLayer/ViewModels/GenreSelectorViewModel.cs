using MixMash.Shared.BL.Contracts;
using MixMash.Shared.BL.Entities;
using MixMash.Shared.BL.ViewModelParameters;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MixMash.Shared.BL.ViewModels
{
    public class GenreSelectorViewModel 
        : MvxViewModel
    {
        private readonly ISpotifyService _spotifyClient;

        public GenreSelectorViewModel(ISpotifyService spotifyClient)
        {
            _spotifyClient = spotifyClient;
            var genres = _spotifyClient.GetGenres().Result;
            SeedGenres = new ObservableCollection<Genre_ListItem>(genres.Select(g => new Genre_ListItem(g.CommonName, g.SpotifyName, this)));
            NextStepText = Constants.GenreSelectorNextStepText;
        }

        private ObservableCollection<Genre_ListItem> _seedGenres;
        public ObservableCollection<Genre_ListItem> SeedGenres
        { 
            get { return _seedGenres; }
            set {
                _seedGenres = value;
                RaisePropertyChanged(() => SeedGenres);
            }
        }

        private string _nextStepText;
        public string NextStepText
        {
            get { return _nextStepText; }
            private set {
                _nextStepText = value;
                RaisePropertyChanged(() => NextStepText);
            }
        }

        private ICommand _nextStepCommand;
        public ICommand NextStepCommand
        { 
            get
            {
                _nextStepCommand = _nextStepCommand ?? new MvxCommand(NextStep);
                return _nextStepCommand;
            }
        }

        private void NextStep()
        {
            var selectedGenres = string.Join(",", SeedGenres.Where(g => g.Selected).Select(g => g.NameValue));
            ShowViewModel<TuneableAttribsSelectorViewModel>(selectedGenres);
        }


        internal void RefreshGenres()
        {
            SeedGenres = new ObservableCollection<Genre_ListItem>(SeedGenres);
        }
    }

    public class Genre_ListItem : MvxNotifyPropertyChanged
    {
        public readonly string NameValue;
        private readonly MvxColor _defaultBackground = MvxColors.Black;
        private GenreSelectorViewModel _container;

        public Genre_ListItem(string name, string nameValue, GenreSelectorViewModel container)
        {
            _name = name;
            NameValue = nameValue;
            Selected = false;
            _backColor = _defaultBackground;
            _container = container;
        }

        private MvxColor _backColor;
        public MvxColor BackColor
        {
            get { return _backColor; }
            private set
            {
                _backColor = value;
                RaisePropertyChanged(() => BackColor);
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            private set {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private ICommand _itemSelectedCommand;
        public ICommand ItemSelectedCommand
        {
            get
            {
                _itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand(SelectItem);
                return _itemSelectedCommand;
            }
        }

        public bool Selected { get; set; }
        public void SelectItem()
        {
            Selected = !Selected;
            BackColor = Selected ? MvxColors.DimGray : _defaultBackground;
            _container.RefreshGenres();
        }
    }
}
