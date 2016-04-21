using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.ValueObjects
{
    public class SpotifyRequestParams
    {
        public List<string> SeedArtists { get; set; }
        public List<string> SeedTracks { get; set; }
        public List<string> SeedGenres { get; set; }

        public int Limit { get; set; }

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
