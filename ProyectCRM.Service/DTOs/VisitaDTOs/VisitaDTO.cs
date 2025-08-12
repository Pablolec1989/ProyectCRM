using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.VisitaUsuarioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs.VisitaDTOs
{
    public class VisitaDTO
    {
        public Guid Id { get; set; }
        public Cliente Cliente { get; set; }
        public Direccion Direccion { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }
        public string Observaciones { get; set; }
        public List<VisitasUsuariosDTO?> Usuarios { get; set; } = [];
    }
}
