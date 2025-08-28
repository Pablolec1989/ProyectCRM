using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class UsuarioDTO : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Guid AreaId { get; set; }
        public Guid RolId { get; set; }
        public AreaDTO Area { get; set; }
        public RolDTO Rol { get; set; }
    }
}
