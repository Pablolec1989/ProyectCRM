using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class VisitaDTO : EntityBase
    {
        public string Observaciones { get; set; }
        public Guid ClienteId { get; set; }
        public Guid DireccionId { get; set; }
        public Guid ArchivoId { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }

        //Propiedades de navegacion
        public ClienteDTO Cliente { get; set; }
        public ICollection<ArchivoDTO> Archivos { get; set; }
        public DireccionDTO DireccionCliente { get; set; }
    }
}
