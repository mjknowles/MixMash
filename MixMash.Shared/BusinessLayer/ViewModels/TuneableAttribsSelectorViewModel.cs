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
        public TuneableAttribsSelectorViewModel()
        {
            _nextStepText = Constants.TuneableAttribsNextStepText;
            _tuneableAttribs = new List<TuneableAttrib_ListItem>()
            {
                new TuneableAttrib_ListItem(TuneableAttrib.Danceability, Constants.TuneableAttribs[TuneableAttrib.Danceability], Constants.MinAttribValue, Constants.MaxAttribValue, Constants.InitialOverallAttribValue)
            };
        }

        private IList<TuneableAttrib_ListItem> _tuneableAttribs;
        public IList<TuneableAttrib_ListItem> TuneableAttribs
        {
            get { return _tuneableAttribs; }
            private set { SetProperty(ref _tuneableAttribs, value); }
        }

        private string _nextStepText;
        public string NextStepText
        {
            get { return _nextStepText; }
            private set { SetProperty(ref _nextStepText, value); }
        }

        private ICommand _nextStepCommand;
        public ICommand NextStepCommand
        {
            get
            {
                var danceability = TuneableAttribs.Where(a => a.TuneableAttribute == TuneableAttrib.Danceability).FirstOrDefault();
                var tracksParams = new TracksParameters()
                {
                    MinDanceability = danceability != null ? danceability.MinValue : 0,
                    MaxDanceability = danceability != null ? danceability.MaxValue : 0,
                };
                return new MvxCommand(() => ShowViewModel<TracksViewModel>(tracksParams));
            }
        }
    }

    public class TuneableAttrib_ListItem : MvxViewModel
    {
        public TuneableAttrib_ListItem(TuneableAttrib tuneableAttrib, string label, float minValue, float maxValue, float overallValue)
        {
            Label = label;
            MinValue = minValue;
            MaxValue = maxValue;
            OverallValue = overallValue;
            TuneableAttribute = tuneableAttrib;
        }

        public float MinValue { get; private set; }
        public float MaxValue { get; private set; }
        public TuneableAttrib TuneableAttribute { get; private set; }

        private string _label;
        public string Label
        {
            get { return _label; }
            private set { SetProperty(ref _label, value); }
        }

        private float _overallValue;
        public float OverallValue
        {
            get { return _overallValue; }
            set {
                MinValue = value > Constants.OverallAttribValueFlex ? value - Constants.OverallAttribValueFlex : Constants.MinAttribValue;
                MaxValue = value < Constants.MaxAttribValue - Constants.OverallAttribValueFlex ? value + Constants.OverallAttribValueFlex : Constants.MaxAttribValue;
                SetProperty(ref _overallValue, value);
            }
        }
    }
}
