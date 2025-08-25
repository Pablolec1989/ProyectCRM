using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class VisitaRequestDTO
    {
        public string Observaciones { get; set; }
        public Guid ClienteId { get; set; }
        public Guid DireccionId { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }
    }
}
