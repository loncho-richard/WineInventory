using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Tasting
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Date {  get; set; }
        public ICollection<string>? Guests { get; set; }
        public ICollection<TastingWine> TastingWine { get; set; }   
    }
}
