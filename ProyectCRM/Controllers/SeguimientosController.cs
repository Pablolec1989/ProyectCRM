using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class SeguimientosController : CustomControllerBase<SeguimientoDTO, SeguimientoUpdateCreateDTO, Seguimiento>
    {
        public SeguimientosController(ISeguimientoService service) : base(service)
        {
        }
    }
}
