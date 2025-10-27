using ProyectCRM.Models.Entities;
using ProyectCRM.Models.SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.FilterModels
{
    public class ClienteFilterPaginated
    {
        public Pagination Pagination { get; set; } = new Pagination();
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public bool? Empresa { get; set; }
        public string? OrderBy { get; set; }
        public bool OrderAsc { get; set; } = true;

    }
}
