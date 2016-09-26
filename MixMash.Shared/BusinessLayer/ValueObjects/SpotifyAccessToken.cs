using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BusinessLayer.ValueObjects
{
    public class SpotifyAccessToken
    {
        public Dictionary<string,string> Properties { get; set; }
        /*public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string Scope { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }*/
    }
}
