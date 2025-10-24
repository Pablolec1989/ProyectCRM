using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Controllers
{
    public class AreasController : CustomControllerBase<AreaDTO, AreaRequestDTO, Area>
    {

        private const string GetAllCacheTag = "Areas:GetAll";
        protected override string CacheTag => GetAllCacheTag;

        public AreasController(IAreaService service, IOutputCacheStore outputCacheStore)
            : base(service, outputCacheStore)
        {
        }

        [HttpGet]
        [OutputCache(Tags = new[] { GetAllCacheTag }, Duration = 60)]
        public override Task<ActionResult<IEnumerable<AreaDTO>>> GetAllAsync()
        {
            return base.GetAllAsync();
        }
    }
}
