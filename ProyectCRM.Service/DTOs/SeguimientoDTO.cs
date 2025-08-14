using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class SeguimientoDTO : EntityBase
    {
        public string Titulo { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaCreacion { get; set; }
        public ClienteDTO Cliente { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
