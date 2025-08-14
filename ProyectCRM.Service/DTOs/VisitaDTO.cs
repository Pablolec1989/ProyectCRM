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
        public ClienteDTO Cliente { get; set; }
        public DireccionClienteDTO DireccionCliente { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }
        public string Observaciones { get; set; }
        public List<VisitasUsuariosDTO?> Usuarios { get; set; } = [];
        public List<VisitaArchivoDTO> Archivos { get; set; }
    }
}
