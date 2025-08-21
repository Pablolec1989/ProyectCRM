using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Interfaces
{
    public interface IAlmacenadorArchivos
    {
        Task<string> Almacenar(string contenedor, IFormFile archivo);
        Task<string> Actualizar(string contenedor, IFormFile archivo, string? ruta);
        Task Borrar(string? ruta, string contenedor);
    }
}
