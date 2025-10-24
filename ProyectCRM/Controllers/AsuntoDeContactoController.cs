using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class AsuntoDeContactoController : CustomControllerBase<AsuntoDeContactoDTO, AsuntoDeContactoRequestDTO, AsuntosDeContacto>
    {
        private const string GetAllCacheTag = "Roles:GetAll";
        protected override string CacheTag => GetAllCacheTag;

        public AsuntoDeContactoController(IAsuntoDeContactoService service, IOutputCacheStore outputCacheStore) 
            : base(service, outputCacheStore)
        {
        }

        [HttpGet]
        [OutputCache(Tags = new[] { GetAllCacheTag }, Duration = 60)]
        public override async Task<ActionResult<IEnumerable<AsuntoDeContactoDTO>>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }
    }
}
