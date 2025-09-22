using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class LlamadaRequestDTO
    {
        public string Detalle { get; set; }
        public Guid ClienteId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid AreaId { get; set; } = Guid.Empty;
        public Guid AsuntoDeContactoId { get; set; }
        public DateTime FechaLlamado { get; set; } = DateTime.Now;
    }
}
