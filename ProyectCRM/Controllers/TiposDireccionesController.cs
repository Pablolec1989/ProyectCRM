using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class TiposDireccionesController : CustomControllerBase<TipoDireccionDTO, TipoDireccionRequestDTO, TipoDireccion>
    {
        public TiposDireccionesController(ITipoDireccionService service) : base(service)
        {
        }

    }
}
