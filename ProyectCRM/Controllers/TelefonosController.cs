using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class TelefonosController : CustomControllerBase<TelefonoDTO, TelefonoRequestDTO, Telefono>
    {
        public TelefonosController(ITelefonoService service, IOutputCacheStore outputCacheStore) 
            : base(service, outputCacheStore)
        {
        }
    }
}
