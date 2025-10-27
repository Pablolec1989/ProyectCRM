using ProyectCRM.Models.Entities;
using ProyectCRM.Models.SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class UsuarioFilterPaginated
    {
        public Pagination Pagination { get; set; } = new Pagination();
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? RolId { get; set; }
        public string? AreaId { get; set; }
        public string? OrderBy { get; set; }
        public bool OrderAsc { get; set; } = true;
    }
}
