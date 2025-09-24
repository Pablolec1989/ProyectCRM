using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class UsuarioDetailDTO : UsuarioDTO
    {
        public List<LlamadaDTO> Llamados { get; set; }
        public List<MailDTO> Mails { get; set; }
        public List<SeguimientoDTO> Seguimientos { get; set; }
        public List<VisitaConUsuariosDTO> Visitas { get; set; }
    }
}
