using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{

    public class RubrosController : CustomControllerBase<RubroDTO, RubroRequestDTO, Rubro>
    {
        private const string GetAllCacheTag = "Rubros:GetAll";
        protected override string CacheTag => GetAllCacheTag;

        public RubrosController(IRubroService service,
            ICacheCleaner cacheCleaner, 
            ILogger<Rubro> logger) 
            : base(service, cacheCleaner, logger)
        {
        }

        [HttpGet]
        [OutputCache(Tags = new[] { GetAllCacheTag }, Duration = 60)]
        public override async Task<ActionResult<IEnumerable<RubroDTO>>> SearchPaginated()
        {
            return await base.SearchPaginated();
        }
    }
}
