using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class DireccionClienteDTO : EntityBase
    {
        public Guid ClienteId { get; set; }
        public ClienteDTO Cliente { get; set; }
        public Guid DireccionId { get; set; }
        public DireccionDTO Direccion { get; set; }
        public ICollection<VisitaDTO> Visitas { get; set; }

    }
}
