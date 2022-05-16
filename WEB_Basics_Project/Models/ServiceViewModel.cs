using System.Collections.Generic;
using System.Linq;

namespace WEB_Basics_Project.Models
{
    public class ServiceViewModel
    {
        public IEnumerable<Domain.Service> Services { get; set; }

        public ServiceViewModel()
            => this.Services = Enumerable.Empty<Domain.Service>();
    }
}