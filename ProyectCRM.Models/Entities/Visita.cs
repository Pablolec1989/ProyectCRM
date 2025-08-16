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
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Guid DireccionClienteId { get; set; }
        public Direccion Direccion { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }
        public string Observaciones { get; set; }
        public List<VisitaUsuario> VisitasUsuarios { get; set; } = [];
        public List<Archivo> Archivos { get; set; }

    }
}
