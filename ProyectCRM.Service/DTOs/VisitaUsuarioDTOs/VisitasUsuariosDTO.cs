using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.UsuarioDTOs;
using ProyectCRM.Service.DTOs.VisitaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs.VisitaUsuarioDTOs
{
    public class VisitasUsuariosDTO
    {
        public List<UsuarioDTO?> Usuarios { get; set; }
        public List<VisitaDTO?> Visitas { get; set; }
    }
}
