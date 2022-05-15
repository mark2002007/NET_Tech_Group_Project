using System.Collections.Generic;

using WEB_Basics_Project.Domain;
using WEB_Basics_Project.Service.Repositories;

namespace WEB_Basics_Project.Service.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;

        public AreaService(IAreaRepository areaRepository)
            => this._areaRepository = areaRepository;

        public List<Area> GetAll()
            => this._areaRepository.GetAll();
    }
}