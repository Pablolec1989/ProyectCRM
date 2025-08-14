using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class ClienteDTO : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public List<TelefonoClienteDTO> TelefonoCliente { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public List<DireccionClienteDTO> Direcciones { get; set; } = [];
        public List<VisitaDTO> Visitas { get; set; } = [];
        public List<LlamadoDTO> Llamados { get; set; }
        public List<MailDTO> Mails { get; set; }
        public List<SeguimientoDTO> Seguimientos { get; set; }

    }
}
