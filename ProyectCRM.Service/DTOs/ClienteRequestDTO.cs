using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class ClienteRequestDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Guid? EmpresaId { get; set; }
        public EmpresaRequestDTO? EmpresaDTO { get; set; }
        public TelefonoClienteRequestDTO Telefono { get; set; }

    }
}
