using MixMash.Shared.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMash.Shared.BL.Entities
{
    public class Genre : BusinessEntityBase
    {
        public string DisplayName { get; set; }
        public string Name { get; set; }
    }
}
