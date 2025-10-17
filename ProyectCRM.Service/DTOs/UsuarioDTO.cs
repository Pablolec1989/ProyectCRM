using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Service.DTOs;
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
        public AreaDTO Area { get; set; }
    }
}
