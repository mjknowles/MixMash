using MixMash.Shared.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.DataAccessLayer.DTOs
{
    public class RecommendationDto
    {
        public IList<TrackDto> Tracks { get; set; }
        public IList<object> Seeds { get; set; }
    }
}
