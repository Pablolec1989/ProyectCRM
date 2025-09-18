using Microsoft.AspNetCore.Http;
using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class ArchivoRequestDTO : EntityBase
    {
        public string NombreArchivo { get; set; }
        public IFormFile RutaArchivo { get; set; }

        public Guid VisitaId { get; set; }
    }
}
