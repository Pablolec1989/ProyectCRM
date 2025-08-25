using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class ClienteRequestDTO : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid TelefonoClienteId { get; set; }
        public Empresa Empresa { get; set; }
        public TelefonoCliente TelefonoCliente { get; set; }

    }
}
