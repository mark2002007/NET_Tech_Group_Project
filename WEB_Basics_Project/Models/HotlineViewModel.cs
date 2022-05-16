using System.Collections.Generic;
using System.Linq;

using WEB_Basics_Project.Domain;

namespace WEB_Basics_Project.Models
{
    public class HotlineViewModel
    {
        public IEnumerable<Area> Areas { get; set; }
        public IEnumerable<Hotline> Hotlines { get; set; }

        public HotlineViewModel()
        {
            this.Areas = Enumerable.Empty<Area>();
            this.Hotlines = Enumerable.Empty<Hotline>();
        }
    }
}