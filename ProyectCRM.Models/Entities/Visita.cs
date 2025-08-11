using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class Visita : EntityBase
    {
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public Guid DireccionClienteId { get; set; }
        public DireccionCliente DireccionCliente { get; set; }
        public Guid VisitaUsuarioId { get; set; }
        public ICollection<VisitasUsuarios> VisitasUsuarios { get; set; }

    }
}
