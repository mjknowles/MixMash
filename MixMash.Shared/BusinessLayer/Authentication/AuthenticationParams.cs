using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.Authentication
{
    public abstract class AuthenticationParams
    {
        public string ClientId { get; set; }
        public string Scope { get; set; }
        public Uri AuthorizeUrl { get; set; }
        public Uri RedirectUrl { get; set; }
        public Uri AccessTokenUrl { get; set; }
    }
}
