using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.SharedDTO
{
    public record PaginationDTO (int Page = 1, int PageSize = 10)
    {
        private const int CantMaxPageSize = 50;
        public int Page { get; init; } = Page < 1 ? 1 : Page;
        public int RecordsPerPage { get; init; } = 
            Math.Clamp(PageSize, 1, CantMaxPageSize);
    }
}
