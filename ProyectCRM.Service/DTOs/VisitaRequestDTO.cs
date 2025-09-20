using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class VisitaRequestDTO
    {
        public string? Observaciones { get; set; }
        public Guid ClienteId { get; set; }
        public Guid DireccionId { get; set; }
        public Guid UsuarioId { get; set; }
        public DateOnly FechaProgramada { get; set; }
        public DateOnly FechaRealizada { get; set; }
    }
}
