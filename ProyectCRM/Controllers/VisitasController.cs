using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class VisitasController : CustomControllerBase<VisitaDTO, VisitaRequestDTO, Visita>
    {
        public VisitasController(IVisitaService service) : base(service)
        {
        }
    }
}
