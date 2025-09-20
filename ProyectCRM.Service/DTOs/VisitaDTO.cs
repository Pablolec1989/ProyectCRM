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
        public DateOnly FechaProgramada { get; set; }
        public DateOnly FechaRealizada { get; set; }
        public string Observaciones { get; set; }

        //Propiedades de navegacion
        public IEnumerable<ArchivoDTO> Archivos { get; set; }
        public DireccionDTO Direccion { get; set; }
    }
}
