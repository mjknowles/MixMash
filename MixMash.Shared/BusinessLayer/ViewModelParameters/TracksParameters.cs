using MixMash.Shared.BL.Entities;
using MixMash.Shared.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.ViewModelParameters
{
    public class TracksParameters
    {
        public IList<TrackViewModel> Tracks { get; set; }
    }
}
