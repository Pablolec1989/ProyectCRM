using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class ClienteDTO : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string? EmpresaRazonSocial { get; set; }
    }
}
