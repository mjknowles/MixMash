using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.ViewModelParameters
{
    public class TuneableAttribsParams
    {
        public TuneableAttribsParams()
        {
            Danceability = .5f;
        }

        public float Danceability { get; set; }
    }
}
