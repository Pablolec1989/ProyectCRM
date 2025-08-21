using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class VisitasController : CustomControllerBase<VisitaDTO, VisitaRequestDTO, Visita>
    {
        public VisitasController(IVisitaService service) : base(service)
        {
        }
    }
}
