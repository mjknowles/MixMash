using MixMash.Shared.BL.Authentication;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace MixMash.Shared.BL.ViewModels
{
    public class SeedSelectorViewModel
        : MvxViewModel
    {
        public SeedSelectorViewModel(IAuthService authService, AuthenticationParams authenticationParams)
        {
            GenresButtonText = "Genres";
            ArtistsButtonText = "Artists";
            SongsButtonText = "Songs";

            authService.Login(authenticationParams);
        }

        private string _genresButtonText;
        public string GenresButtonText
        {
            get { return _genresButtonText; }
            private set { SetProperty(ref _genresButtonText, value); }
        }

        private string _artistsButtonText;
        public string ArtistsButtonText
        {
            get { return _artistsButtonText; }
            private set { SetProperty(ref _artistsButtonText, value); }
        }

        private string _songsButtonText;
        public string SongsButtonText
        {
            get { return _songsButtonText; }
            private set { SetProperty(ref _songsButtonText, value); }
        }

        public ICommand GenreSelectedCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<GenreSelectorViewModel>());
            }
        }
    }
}
