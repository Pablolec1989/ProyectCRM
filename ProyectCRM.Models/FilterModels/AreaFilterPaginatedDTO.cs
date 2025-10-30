using ProyectCRM.Models.SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.FilterModels
{
    public class AreaFilterPaginatedDTO
    {
        public PaginationDTO Pagination { get; set; } = new PaginationDTO();
        public string? Nombre { get; set; }
    }
}
