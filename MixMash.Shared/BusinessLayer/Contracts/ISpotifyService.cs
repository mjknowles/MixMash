using MixMash.Shared.BL.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.Contracts
{
    public interface ISpotifyService
    {
        Task<IList<SpotifyGenre>> GetGenresAsync();
    }
}
