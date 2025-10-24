using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.SharedDTO
{
    public record PaginationDTO (int Page = 1, int RecordsPerPage = 10)
    {
        private const int CantMaxRecordsPerPage = 50;
        public int Page { get; init; } = Page < 1 ? 1 : Page;
        public int RecordsPerPage { get; init; } = 
            Math.Clamp(RecordsPerPage, 1, CantMaxRecordsPerPage);
    }
}
