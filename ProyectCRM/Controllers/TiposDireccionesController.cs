using Microsoft.AspNetCore.Mvc;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.TipoDireccionDTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class TiposDireccionesController : CustomControllerBase<TipoDireccionDTO, TipoDireccionUpdateCreateDTO, TipoDireccion>
    {
        public TiposDireccionesController(ITipoDireccionService service) : base(service)
        {
        }

    }
}
