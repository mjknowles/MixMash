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
using System.IO;
using MixMash.Shared.DataAccessLayer.DTOs;

namespace MixMash.Shared.DAL.Clients
{
    public class SpotifyService : ISpotifyService
    {
        public async Task<IList<SpotifyGenre>> GetGenresAsync()
        {
            /*return new List<string>
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
            };*/
            var genres = new List<SpotifyGenre>();
            var account = AccountStore.Create().FindAccountsForService("Spotify").FirstOrDefault();
            var request = new OAuth2Request("GET", new Uri(ApiRecommendationsGenresAddress), null, account);
            var response = await request.GetResponseAsync().ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var text = String.Empty;
                using (var s = await response.GetResponseStreamAsync())
                {
                    using (var r = new StreamReader(s, Encoding.UTF8))
                    {
                        text = await r.ReadToEndAsync();
                    }
                }
                if (!string.IsNullOrWhiteSpace(text))
                {
                    var genresDto = await Task.Run(() =>
                        JsonConvert.DeserializeObject<GenresDto>(text)
                    ).ConfigureAwait(false);

                    genres = await Task.Run(() =>
                        Mapper.Map<List<SpotifyGenre>>(genresDto.Genres)
                    ).ConfigureAwait(false);
                }
            }

            return genres;
        }

        public async Task<List<Track>> GetRecommendedTracks(SpotifyRequestParams spotifyRequestParams)
        {
            List<TrackDto> trackDtos = new List<TrackDto>();
            List<Track> tracks = new List<Track>();

            var bodyParam = new Dictionary<string, string>();
            bodyParam.Add("seed_genres", "dance");
            bodyParam.Add("max_tempo", spotifyRequestParams.MaxTempo.ToString());
            bodyParam.Add("min_tempo", spotifyRequestParams.MinTempo.ToString());

            var account = AccountStore.Create().FindAccountsForService("Spotify").FirstOrDefault();
            var request = new OAuth2Request("GET", new Uri(ApiRecommendationsAddress), bodyParam, account);
            //using (var httpClient = await CreateClient())
            var response = await request.GetResponseAsync().ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var text = String.Empty;
                using (var s = await response.GetResponseStreamAsync())
                {
                    using (var r = new StreamReader(s, Encoding.UTF8))
                    {
                        text = await r.ReadToEndAsync();
                    }
                }

                //var text = await response.GetResponseTextAsync().ConfigureAwait(false);
                if (!string.IsNullOrWhiteSpace(text))
                {
                    trackDtos = await Task.Run(() =>
                        JsonConvert.DeserializeObject<RecommendationDto>(text).Tracks.ToList()
                    ).ConfigureAwait(false);

                    tracks = await Task.Run(() =>
                        Mapper.Map<List<TrackDto>, List<Track>>(trackDtos)
                    ).ConfigureAwait(false);
                }
            }

            return tracks;
        }

        private const string ApiRecommendationsAddress = "https://api.spotify.com/v1/recommendations";
        private const string ApiRecommendationsGenresAddress = "https://api.spotify.com/v1/recommendations/available-genre-seeds";
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
