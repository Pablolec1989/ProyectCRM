using ProyectCRM.Models.Entities;
using ProyectCRM.Models.SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.FilterModels
{
    public class VisitaFilterPaginated
    {
        public Pagination Pagination { get; set; } = new Pagination();
        public bool? Archivos { get; set; }
        public DateTime? FechaProgramadaDesde { get; set; }
        public DateTime? FechaProgramadaHasta { get; set; }
        public DateTime? FechaRealizadaDesde { get; set; }
        public DateTime? FechaRealizadaHasta { get; set; }
    }
}
