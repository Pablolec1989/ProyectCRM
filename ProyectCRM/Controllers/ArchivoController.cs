using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Service.DTOs;
using ProyectCRM.Models.Service.Interfaces;
using ProyectCRM.Models.Service.Services;
using ProyectCRM.Service.DTOs;

namespace ProyectCRM.Models.Controllers
{
    public class ArchivoController : CustomControllerBase<ArchivoDTO, ArchivoRequestDTO, Archivo>
    {
        public ArchivoController(IArchivoService service) : base(service)
        {
        }
    }
}
