using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class EmpresaController : CustomControllerBase<EmpresaDTO, EmpresaRequestDTO, Empresa>
    {
        public EmpresaController(IEmpresaService service) : base(service)
        {
        }
    }
}
