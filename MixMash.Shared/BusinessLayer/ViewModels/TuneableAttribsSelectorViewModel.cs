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
                new TuneableAttrib_ListItem(TuneableAttrib.Tempo, Constants.TuneableAttribs[TuneableAttrib.Tempo], Constants.InitialOverallAttribValue)
            };
        }

        public void Init(string genres)
        {
            _genres = genres;
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
        public TuneableAttrib_ListItem(TuneableAttrib tuneableAttrib, string label, float overallValue)
        {
            Label = label;
            OverallValue = overallValue;
            TuneableAttribute = tuneableAttrib;
        }

        public float _minValue;
        public float MinValue { get; private set; }

        public float _maxValue;
        public float MaxValue { get; private set; }

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

        private float _overallValue;
        public float OverallValue
        {
            get { return _overallValue; }
            set {
                _minValue = value > Constants.OverallAttribValueFlex ? value - Constants.OverallAttribValueFlex : Constants.MinAttribValue;
                RaisePropertyChanged(() => MinValue);
                _maxValue = value < Constants.MaxAttribValue - Constants.OverallAttribValueFlex ? value + Constants.OverallAttribValueFlex : Constants.MaxAttribValue;
                RaisePropertyChanged(() => MaxValue);
                _overallValue = value;
                RaisePropertyChanged(() => OverallValue);
            }
        }
    }
}
