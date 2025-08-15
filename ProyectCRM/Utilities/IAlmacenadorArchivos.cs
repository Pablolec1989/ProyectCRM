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
        Task<string> Almacenar(string contenedor, IFormFile archivo);
        async Task<string> Actualizar(string contenedor, IFormFile archivo, string? ruta)
        {
            await Borrar(ruta, contenedor);
            return await Almacenar(contenedor, archivo);
        }
        Task Borrar(string? ruta, string contenedor);
    }
}
