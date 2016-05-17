using MixMash.Shared.BL.ViewModelParameters;
using MixMash.Shared.BL.ValueObjects;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.ViewModels
{
    public class TuneableAttribsSelectorViewModel : MvxViewModel
    {
        public void Init(TuneableAttribsParams tuneableAttribsParams)
        {
            _danceability = tuneableAttribsParams.Danceability;
        }

        private float _danceability;
        public float Danceablity
        {
            get { return _danceability; }
            set { SetProperty(ref _danceability, value); }
        }
    }
}
