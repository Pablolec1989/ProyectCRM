using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Utilities
{
    public interface IAlmacenadorArchivos
    {
        Task<string> CreateAsync(string contenedor, IFormFile archivo);
        Task<string> UpdateAsync(string contenedor, IFormFile archivo, string? ruta);
        Task DeleteAsync(string? ruta, string contenedor);
    }
}
