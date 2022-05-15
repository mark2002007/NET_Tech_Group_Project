using System.Collections.Generic;
using System.Linq;

using WEB_Basics_Project.Domain;

namespace WEB_Basics_Project.Models
{
    public class HotlineViewModel
    {
        public IEnumerable<Area> areas { get; set; }
        public IEnumerable<Hotline> hotlines { get; set; }

        public HotlineViewModel()
        {
            this.areas = Enumerable.Empty<Area>();
            this.hotlines = Enumerable.Empty<Hotline>();
        }
    }
}