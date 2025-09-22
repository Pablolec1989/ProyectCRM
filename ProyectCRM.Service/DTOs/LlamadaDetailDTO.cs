using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class LlamadaDetailDTO : LlamadaDTO
    {
        public ClienteDTO Cliente { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public AreaDTO Area { get; set; }

    }
}
