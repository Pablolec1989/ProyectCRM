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
        public List<TelefonoClienteDTO> TelefonosCliente { get; set; }
        public List<DireccionDTO> DireccionesCliente { get; set; } = [];
        public List<VisitaDTO> VisitasCliente { get; set; } = [];
        public List<LlamadoDTO> LlamadosCliente { get; set; }
        public List<MailDTO> MailsCliente { get; set; }
        public List<SeguimientoDTO> SeguimientosCliente { get; set; }
        public Guid EmpresaId { get; set; }
        public EmpresaDTO EmpresaCliente { get; set; }

    }
}
