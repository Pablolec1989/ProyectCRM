using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class SeguimientoDTO : EntityBase
    {
        public string Titulo { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
