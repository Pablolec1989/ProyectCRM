using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class UsuarioUpdateCreateDTO : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public Guid RolId { get; set; }
        public Guid AreaId { get; set; }
        public Guid VisitaUsuarioId { get; set; }
    }
}
