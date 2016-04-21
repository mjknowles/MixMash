using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.Contracts
{
    public interface ISpotifyClient
    {
        Task<IList<string>> GetGenres();
    }
}
