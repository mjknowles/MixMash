using MixMash.Shared.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.Constants
{
    public static class Constants
    {
        public static Dictionary<Genre, string> Genres = new Dictionary<Genre, string>
        {
            { Genre.AltRock, "alt_rock" },
            { Genre.Bluegrass, "bluegrass" },
            { Genre.Blues, "blues" },
            { Genre.Classical, "classical" },
            { Genre.Country, "country" },
            { Genre.Dance, "dance" },
            { Genre.Electronic, "electronic" },
            { Genre.Happy, "happy" },
            { Genre.IndiePop, "indie-pop" },
            { Genre.NewRelease, "new-release" },
            { Genre.Party, "party" },
            { Genre.Pop, "pop" },
            { Genre.Salsa, "salsa" },
            { Genre.Techno, "techno" },
            { Genre.WorkOut, "work-out" },
        };
    }
}
