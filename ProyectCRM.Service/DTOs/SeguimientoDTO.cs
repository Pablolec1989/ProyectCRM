using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class SeguimientoDTO : EntityBase
    {
        public string Titulo { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ClienteId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid? MailId { get; set; }
        public Guid? LlamadoId { get; set; }
        public Guid? VisitaId { get; set; }
        public ClienteDTO Cliente { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public MailDTO Mail { get; set; }
        public LlamadaDTO Llamado { get; set; }
        public VisitaDTO Visita { get; set; }
    }
}
