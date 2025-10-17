using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class UsuarioRequestDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Guid? AreaId { get; set; }

    }
}
