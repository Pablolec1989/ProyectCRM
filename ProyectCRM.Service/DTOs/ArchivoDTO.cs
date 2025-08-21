using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class ArchivoDTO : EntityBase
    {
        public string NombreArchivo { get; set; }
        public string RutaArchivo { get; set; }
        public DateTime FechaSubida { get; set; }
        public Guid VisitaId { get; set; }
        public Guid EmpresaId { get; set; }

    }
}
