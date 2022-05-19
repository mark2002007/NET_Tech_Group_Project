using System.Collections.Generic;
using System.Linq;

using WEB_Basics_Project.Domain;

namespace WEB_Basics_Project.Models
{
    public class ServicesViewModel
    {
        public IEnumerable<ServiceView> Services { get; set; }

        public ServicesViewModel()
            => this.Services = Enumerable.Empty<ServiceView>();
    }
}