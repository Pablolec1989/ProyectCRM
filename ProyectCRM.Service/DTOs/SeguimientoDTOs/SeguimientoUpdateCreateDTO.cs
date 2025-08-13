using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs.SeguimientoDTOs
{
    public class SeguimientoUpdateCreateDTO : EntityBase
    {
        public string Titulo { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ClienteId { get; set; }
        public Guid UsuarioId { get; set; }

    }
}
