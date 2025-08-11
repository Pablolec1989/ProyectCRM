using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.RolDTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class RolesController : CustomControllerBase<RolDTO, RolCreateDTO, Rol>
    {
        public RolesController(IRolService service) : base(service)
        {
        }
    }
}
