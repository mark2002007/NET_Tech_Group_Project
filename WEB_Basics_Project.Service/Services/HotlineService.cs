using System.Collections.Generic;

using WEB_Basics_Project.Domain;
using WEB_Basics_Project.Service.Repositories;

namespace WEB_Basics_Project.Service.Services
{
    public class HotlineService : IHotlineService
    {
        private readonly IHotlineRepository _hotlineRepository;

        public HotlineService(IHotlineRepository hotlineRepository)
            => this._hotlineRepository = hotlineRepository;

        public List<Hotline> GetAll()
            => this._hotlineRepository.GetAll();
    }
}