using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.Authentication
{
    public interface IAuthService
    {
        void Login(AuthenticationParams authParams);
    }
}
