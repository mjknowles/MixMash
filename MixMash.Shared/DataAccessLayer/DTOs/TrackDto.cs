namespace MixMash.Shared.DAL.DTOs
{
    public class TrackDto
    {
        public ArtistDto[] Artists { get; set; }
        public string[] AvailableMarkets { get; set; }
        public int DiscNumber { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        //public string[] ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public bool IsPlayable { get; set; }
        public string Name { get; set; }
        public string PreviewUrl { get; set; }
        public int TrackNumber { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class ArtistDto { public string Name { get; set; }
    }
}
