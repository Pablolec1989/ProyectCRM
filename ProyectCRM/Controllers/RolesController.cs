using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;

namespace ProyectCRM.Controllers
{
    public class RolesController : CustomControllerBase<RolDTO, RolUpdateCreateDTO, Rol>
    {
        public RolesController(IRolService service) : base(service)
        {
        }
    }
}
