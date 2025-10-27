using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class TiposTelefonosController : CustomControllerBase<TipoTelefonoDTO, TipoTelefonoRequestDTO, TiposTelefono>
    {
        public TiposTelefonosController(ITipoTelefonoService service, IOutputCacheStore outputCacheStore,
            ILogger<TiposTelefono> logger) 
            : base(service, outputCacheStore, logger)
        {
        }
    }
}
