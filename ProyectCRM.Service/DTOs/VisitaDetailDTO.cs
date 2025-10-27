using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class VisitaDetailDTO : VisitaDTO
    {
        public string Observaciones { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }

        public List<ArchivoDTO> Archivos { get; set; }
        public List<UsuarioDTO> Usuarios { get; set; }
    }
}
