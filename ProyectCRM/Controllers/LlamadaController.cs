using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class LlamadaController : CustomControllerBase<LlamadaDTO, LlamadaRequestDTO, Llamada>
    {
        public LlamadaController(ILlamadoService service) : base(service) 
        {
        }
    }
}
