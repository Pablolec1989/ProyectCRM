using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class ArchivoController : CustomControllerBase<ArchivoDTO, ArchivoUpdateCreateDTO, Archivo>
    {
        public ArchivoController(IArchivoService service) : base(service)
        {
        }
    }
}
