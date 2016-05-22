using MixMash.Shared.BL.Entities;
using MixMash.Shared.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.ViewModelParameters
{
    public class TracksParameters
    {
        public TracksParameters()
        {
            MaxAcousticness = 0;
            MaxDanceability = 0;
            MaxDurationMs = 0;
            MaxEnergy = 0;
            MaxLoudness = 0;
            MaxPopularity = 0;
            MaxTempo = 0;
            MaxValence = 0;

            MinAcousticness = 0;
            MinDanceability = 0;
            MinDurationMs = 0;
            MinEnergy = 0;
            MinLoudness = 0;
            MinPopularity = 0;
            MinTempo = 0;
            MinValence = 0;
        }

        public float MaxAcousticness { get; set; }
        public float MaxDanceability { get; set; }
        public int MaxDurationMs { get; set; }
        public float MaxEnergy { get; set; }
        public float MaxLoudness { get; set; }
        public int MaxPopularity { get; set; }
        public float MaxTempo { get; set; }
        public float MaxValence { get; set; }

        public float MinAcousticness { get; set; }
        public float MinDanceability { get; set; }
        public int MinDurationMs { get; set; }
        public float MinEnergy { get; set; }
        public float MinLoudness { get; set; }
        public int MinPopularity { get; set; }
        public float MinTempo { get; set; }
        public float MinValence { get; set; }
    }
}
