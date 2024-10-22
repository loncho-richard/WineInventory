using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class TastingWine
    {
        public int WineId { get; set; }
        public Wine Wine { get; set; }
        public int TastingWineId { get; set; }
    }
}
