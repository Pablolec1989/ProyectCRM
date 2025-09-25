using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Controllers
{
    public class RolesController : CustomControllerBase<RolDTO, RolRequestDTO, Rol>
    {
        public RolesController(IRolService service) : base(service)
        {
        }
    }
}
