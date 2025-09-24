using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Service.DTOs
{
    public class VisitaConUsuariosDTO : EntityBase
    {
        public ClienteDTO Cliente { get; set; }
        public DireccionDTO Direccion { get; set; }
        public List<UsuarioDTO> Usuarios { get; set; }
    }
}
