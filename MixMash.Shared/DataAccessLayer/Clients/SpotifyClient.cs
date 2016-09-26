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
using Xamarin.Auth;
using MixMash.Shared.BusinessLayer.ValueObjects;
using MixMash.Shared.BL.ValueObjects;

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

        public async Task<List<Track>> GetRecommendedTracks(SpotifyRequestParams spotifyRequestParams)
        {
            IEnumerable<TrackDto> trackDtos = Enumerable.Empty<TrackDto>();
            IEnumerable<Track> tracks = Enumerable.Empty<Track>();

            var bodyParam = new Dictionary<string, string>();
            bodyParam.Add("seed_genres", "dance");
            bodyParam.Add("max_danceability", spotifyRequestParams.MaxDanceability.ToString());
            bodyParam.Add("min_danceability", spotifyRequestParams.MinDanceability.ToString());

            var account = AccountStore.Create().FindAccountsForService("Spotify").FirstOrDefault();
            var request = new OAuth2Request("GET", new Uri(ApiRecommendationsAddress), bodyParam, account);
            //using (var httpClient = await CreateClient())
            var response = await request.GetResponseAsync().ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var text = await response.GetResponseTextAsync().ConfigureAwait(false);
                if (!string.IsNullOrWhiteSpace(text))
                {
                    trackDtos = await Task.Run(() =>
                        JsonConvert.DeserializeObject<IEnumerable<TrackDto>>(text)
                    ).ConfigureAwait(false);

                    tracks = await Task.Run(() =>
                        _mapper.Map<IEnumerable<Track>>(trackDtos)
                    ).ConfigureAwait(false);
                }
            }

            return tracks.ToList();
        }

        private const string ApiRecommendationsAddress = "http://api.spotify.com/v1/recommendations";
        private const string AccessTokenAddress = "https://accounts.spotify.com/api/token";
        /*private async Task<HttpClient> CreateClient()
        {
            /*
var request = new OAuth2Request ("GET", new Uri (Constants.UserInfoUrl), null, e.Account);
var response = await request.GetResponseAsync ();
if (response != null) {
  string userJson = response.GetResponseText ();
  App.User = JsonConvert.DeserializeObject<User> (userJson);
  ...
}
*/
            /*OAuth2Request request;
            var account = AccountStore.Create().FindAccountsForService("Spotify").FirstOrDefault();
            if (account != null)
            {
                //Dictionary<string, string> bodyParam = new Dictionary<string, string>();
                //bodyParam.Add("grant_type", "authorization_code");
                //bodyParam.Add("code", account.Properties[]);
                //bodyParam.Add("redirect_uri", "authorization_code");

                /*request = new OAuth2Request("GET", new Uri(AccessTokenAddress), null, account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    var r = response.GetResponseText();
                    var accessToken = JsonConvert.DeserializeObject<SpotifyAccessToken>(response.GetResponseText());
                    account.Properties.Add("AccessToken", accessToken.Properties["access_token"]);
                }*/
                /*var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(ApiBaseAddress)
                };

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return httpClient;
            }
            //TODO remove
            return null;
        }*/
    }
}
