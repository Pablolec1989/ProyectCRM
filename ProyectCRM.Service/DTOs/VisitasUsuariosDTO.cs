using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class VisitasUsuariosDTO
    {
        public ICollection<UsuarioDTO?> Usuarios { get; set; }
        public ICollection<VisitaDTO?> Visitas { get; set; }
    }
}
