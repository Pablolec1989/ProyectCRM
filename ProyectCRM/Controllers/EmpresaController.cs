using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;

namespace ProyectCRM.Models.Controllers
{
    public class EmpresaController : CustomControllerBase<EmpresaDTO, EmpresaRequestDTO, Empresa>
    {
        public EmpresaController(IEmpresaService service) : base(service)
        {
        }
    }
}
