using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class LlamadoRequestDTO : EntityBase
    {
        public string Detalle { get; set; }
        public Guid AsuntoDeContactoId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime FechaLlamado { get; set; } = DateTime.Now;

    }
}
