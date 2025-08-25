using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class VisitaDTO
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public ClienteDTO Cliente { get; set; }
        public Guid DireccionId { get; set; }
        public DireccionDTO DireccionCliente { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }
        public string Observaciones { get; set; }
        public List<VisitaUsuarioDTO?> Usuarios { get; set; } = [];
        public List<ArchivoDTO> Archivos { get; set; }
    }
}
