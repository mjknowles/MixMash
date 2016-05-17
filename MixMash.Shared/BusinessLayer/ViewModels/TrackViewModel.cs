using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.ViewModels
{
    public class TrackViewModel : MvxViewModel
    {
        public TrackViewModel(string name, string artist)
        {
            Name = name;
            Artist = artist;
        }

        private string _artist;
        public string Artist
        {
            get { return _artist; }
            set { SetProperty(ref _artist, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}
