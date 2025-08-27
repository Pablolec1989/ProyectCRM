using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class SeguimientosController : CustomControllerBase<SeguimientoDTO, SeguimientoRequestDTO, Seguimiento>
    {
        public SeguimientosController(ISeguimientoService service) : base(service)
        {
        }
    }
}
