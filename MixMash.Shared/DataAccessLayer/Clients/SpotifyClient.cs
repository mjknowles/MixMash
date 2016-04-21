using AutoMapper;
using MixMash.Shared.BL.Entities;
using MixMash.Shared.BL.Contracts;
using MixMash.Shared.DAL.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.DAL.Clients
{
    public class SpotifyClient : ISpotifyClient
    {
        private IMapper _mapper;

        public SpotifyClient(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IList<string>> GetGenres()
        {
            return new List<string>
            {
                "alt_rock",
                "bluegrass",
                "blues",
                "classical",
                "country",
                "dance",
                "electronic",
                "happy",
                "indie-pop",
                "new-release",
                "party",
                "pop",
                "salsa",
                "techno",
                "work-out"
            };
        }

        public async Task<List<Track>> GetRecommendedTracks()
        {
            IEnumerable<TrackDto> trackDtos = Enumerable.Empty<TrackDto>();
            IEnumerable<Track> tracks = Enumerable.Empty<Track>();

            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync("recommendations").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        trackDtos = await Task.Run(() =>
                           JsonConvert.DeserializeObject<IEnumerable<TrackDto>>(json)
                        ).ConfigureAwait(false);

                        tracks = await Task.Run(() =>
                            _mapper.Map<IEnumerable<Track>>(trackDtos)
                        ).ConfigureAwait(false);
                    }
                }
            }

            return tracks.ToList();
        }

        private const string ApiBaseAddress = "http://api.spotify.com/v1/";
        private HttpClient CreateClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseAddress)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
