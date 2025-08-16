using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class LlamadaController : CustomControllerBase<LlamadoDTO, LlamadoUpdateCreateDTO, Llamado>
    {
        public LlamadaController(ILlamadoService service) : base(service) 
        {
        }
    }
}
