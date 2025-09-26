using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class ClienteDetailDTO : ClienteDTO
    {
        public List<DireccionDetailDTO?> Direcciones { get; set; }
        public List<TelefonoDTO?> Telefonos { get; set; }
        public List<MailDTO?> Mails { get; set; }
        public List<SeguimientoDTO?> Seguimientos { get; set; }
        public List<LlamadaDTO?> Llamados { get; set; }
        public List<VisitaDTO?> Visitas { get; set; }

    }
}
