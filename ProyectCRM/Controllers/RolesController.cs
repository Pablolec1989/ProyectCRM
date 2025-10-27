using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Controllers
{
    public class RolesController : CustomControllerBase<RolDTO, RolRequestDTO, Rol>
    {
        private const string GetAllCacheTag = "Roles:GetAll";
        protected override string CacheTag => GetAllCacheTag;

        public RolesController(IRolService service,
            ICacheCleaner cacheCleaner, 
            ILogger<Rol> logger)
            : base(service, cacheCleaner, logger)
        {
        }

        [HttpGet]
        [OutputCache(Tags = new[] { GetAllCacheTag }, Duration = 60)]
        public override Task<ActionResult<IEnumerable<RolDTO>>> GetAllAsync()
        {
            return base.GetAllAsync();
        }
    }
}
