using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class CondicionIvaController : CustomControllerBase<CondicionIvaDTO, CondicionIvaRequestDTO, CondicionIva>
    {
        private const string GetAllCacheTag = "CondicionIva:GetAll";
        protected override string CacheTag => GetAllCacheTag;
        public CondicionIvaController(ICondicionIvaService service, 
            IOutputCacheStore outputCacheStore, ILogger<CondicionIva> logger) : base(service, outputCacheStore, logger)
        {
        }
        
        [HttpGet]
        [OutputCache(Tags = new[] { GetAllCacheTag }, Duration = 60)]
        public override Task<ActionResult<IEnumerable<CondicionIvaDTO>>> GetAllAsync()
        {
            return base.GetAllAsync();
        }
    }
}
