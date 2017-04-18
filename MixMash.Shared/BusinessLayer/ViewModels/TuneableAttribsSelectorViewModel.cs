using MixMash.Shared.BL.ViewModelParameters;
using MixMash.Shared.BL.ValueObjects;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MixMash.Shared.BL.Enums;
using System.Windows.Input;
using MixMash.Shared.BusinessLayer.ViewModelParameters;

namespace MixMash.Shared.BL.ViewModels
{
    public class TuneableAttribsSelectorViewModel : MvxViewModel
    {
        private string _genres;

        public TuneableAttribsSelectorViewModel()
        {
            _nextStepText = Constants.TuneableAttribsNextStepText;
            _tuneableAttribs = new List<TuneableAttrib_ListItem>()
            {
                new TuneableAttrib_ListItem(TuneableAttrib.Tempo, Constants.TuneableAttribs[TuneableAttrib.Tempo], Constants.InitialMinTempoAttribValue, Constants.InitialMaxTempoAttribValue)
            };
        }

        public void Init(GenresParameters genres)
        {
            _genres = genres.Genres;
        }

        private IList<TuneableAttrib_ListItem> _tuneableAttribs;
        public IList<TuneableAttrib_ListItem> TuneableAttribs
        {
            get { return _tuneableAttribs; }
            private set {
                RaisePropertyChanged(() => TuneableAttribs);
                _tuneableAttribs = value;
            }
        }

        private string _nextStepText;
        public string NextStepText
        {
            get { return _nextStepText; }
            private set {
                RaisePropertyChanged(() => NextStepText);
                _nextStepText = value; }
        }

        private ICommand _nextStepCommand;
        public ICommand NextStepCommand
        {
            get
            {
                var tempo = TuneableAttribs.Where(a => a.TuneableAttribute == TuneableAttrib.Tempo).FirstOrDefault();
                var tracksParams = new TracksParameters()
                {
                    MinTempo = tempo != null ? tempo.MinValue : 0,
                    MaxTempo = tempo != null ? tempo.MaxValue : 0,
                };
                return new MvxCommand(() => ShowViewModel<TracksViewModel>(tracksParams));
            }
        }
    }

    public class TuneableAttrib_ListItem : MvxViewModel
    {
        public TuneableAttrib_ListItem(TuneableAttrib tuneableAttrib, string label, int initialMinValue, int initialMaxValue)
        {
            _label = label;
            _minValue = initialMinValue;
            _maxValue = initialMaxValue;
            TuneableAttribute = tuneableAttrib;
        }

        public int _minValue;
        public int MinValue
        {
            get { return _minValue; }
            private set
            {
                _minValue = value;
                RaisePropertyChanged(() => MinValue);

            }
        }

        public float _maxValue;
        public float MaxValue
        {
            get { return _maxValue; }
            private set
            {
                _maxValue = value;
                RaisePropertyChanged(() => MaxValue);

            }
        }

        public TuneableAttrib TuneableAttribute { get; private set; }

        private string _label;
        public string Label
        {
            get { return _label; }
            private set {
                _label = value;
                RaisePropertyChanged(() => Label);
            }
        }

        private ICommand _itemSelectedCommand;
        public ICommand ItemSelectedCommand
        {
            get
            {
                _itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand(() => ShowViewModel<TuneableAttribsDetailViewModel>());
                return _itemSelectedCommand;
            }
        }
    }

    public class TuneableAttribsDetailViewModel : MvxViewModel
    {
        public void Init(TuneableAttrib id, string name, int min, int max)
        {
        }

        public Enums.TuneableAttrib Id { get; set; }
        public string Name { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
