using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class SeguimientoRequestDTO : EntityBase
    {
        public string Titulo { get; set; }
        public string Detalle { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid? MailId { get; set; }
        public Guid? LlamadoId { get; set; }
        public Guid? VisitaId { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}
