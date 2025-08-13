using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.AreaDTOs;
using ProyectCRM.Service.DTOs.RolDTOs;
using ProyectCRM.Service.DTOs.VisitaUsuarioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs.UsuarioDTOs
{
    public class UsuarioDTO : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public RolDTO Rol { get; set; }
        public AreaDTO Area { get; set; }
        public List<VisitasUsuariosDTO> Visitas { get; set; } = [];

    }
}
