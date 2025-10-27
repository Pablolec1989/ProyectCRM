using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class TiposDireccionesController : CustomControllerBase<TipoDireccionDTO, TipoDireccionRequestDTO, TipoDireccion>
    {
        public TiposDireccionesController(ITipoDireccionService service, IOutputCacheStore outputCacheStore, ILogger<TipoDireccion> logger) 
            : base(service, outputCacheStore, logger)
        {
        }

    }
}
