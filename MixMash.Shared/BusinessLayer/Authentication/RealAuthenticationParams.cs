using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.Authentication
{
    public class RealAuthenticationParams : AuthenticationParams
    {
        public RealAuthenticationParams()
        {
            ClientId = "e0c5aa96878744b987515001757dd60a";
            Scope = "";
            AuthorizeUrl = new Uri("https://accounts.spotify.com/authorize");
            AccessTokenUrl = new Uri("https://accounts.spotify.com/api/token");
            RedirectUrl = new Uri("com.mjknowles.mixmash://callback/");
        }
    }
}
