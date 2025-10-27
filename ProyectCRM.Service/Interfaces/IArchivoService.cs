using Microsoft.AspNetCore.Http;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.Interfaces
{
    public interface IArchivoService : IServiceBase<ArchivoDTO, ArchivoRequestDTO, Archivo>
    {
        Task<ArchivoDTO?> CreateAsync(ArchivoRequestDTO dto, IFormFile archivo);
        Task<ArchivoDTO?> UpdateAsync(Guid id, ArchivoRequestDTO dto, IFormFile? archivo);
    }
}
