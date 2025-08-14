using ProyectCRM.Models.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class VisitaArchivoUpdateCreateDTO
    {
        public string NombreArchivo { get; set; }
        public IFormFile RutaArchivo { get; set; }
        public DateTime FechaSubida { get; set; }
        public Guid VisitaId { get; set; }
        public Guid EmpresaId { get; set; }
    }
}
