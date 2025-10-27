using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Utils
{
    public interface IFileStorageService
    {
        Task<string> CreateFileAsync(string contenedor, IFormFile archivo);
        Task<string> UpdateFileAsync(string contenedor, IFormFile archivo, string? ruta);
        Task DeleteFileAsync(string? ruta, string contenedor);
    }
}
