using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class ArchivoRequestDTO
    {
        public string NombreArchivo { get; set; }
        public string RutaArchivo { get; set; }
        public Guid VisitaId { get; set; }
        public Guid EmpresaId { get; set; }
        public DateTime FechaSubida { get; set; } = DateTime.UtcNow;
    }
}
