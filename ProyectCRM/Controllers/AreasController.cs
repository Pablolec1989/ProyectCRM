using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.FilterModels;
using ProyectCRM.Models.Service;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Models.SharedDTO;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;
using ProyectCRM.Utils;

namespace ProyectCRM.Models.Controllers
{
    public class AreasController : CustomControllerBase<AreaDTO, AreaRequestDTO, AreaFilterPaginatedDTO, Area>
    {

        private const string GetAllCacheTag = "Areas:GetAll";
        protected override string CacheTag => GetAllCacheTag;


        public AreasController(IAreaService service,
            ICacheCleaner cacheCleaner, ILogger<Area> logger)
            : base(service, cacheCleaner, logger)
        {
        }

        
    }
}
