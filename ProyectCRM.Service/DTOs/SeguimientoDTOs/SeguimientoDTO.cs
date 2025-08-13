using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs.SeguimientoDTOs
{
    public class SeguimientoDTO : EntityBase
    {
        public string Titulo { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
    }
}
