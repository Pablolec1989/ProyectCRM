using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class UsuarioRegisterDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public Guid AreaId { get; set; }
        public Guid RolId { get; set; }
    }
}
