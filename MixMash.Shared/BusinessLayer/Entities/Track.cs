using MixMash.Shared.BL.Entities;

namespace MixMash.Shared.BL.Entities
{
    public class Track : BusinessEntityBase
    {
        public TrackArtist[] Artists { get; set; }
        public string[] AvailableMarkets { get; set; }
        public int DiscNumber { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        //public string[] ExternalUrls { get; set; }
        public string Href { get; set; }
        public string SpotifyId { get; set; }
        public bool IsPlayable { get; set; }
        public string Name { get; set; }
        public string PreviewUrl { get; set; }
        public int TrackNumber { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class TrackArtist { public string Name { get; set; } }

}
