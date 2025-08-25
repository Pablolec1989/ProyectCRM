using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class TelefonoClienteRequestDTO : EntityBase
    {
        public string Numero { get; set; }
        public Guid ClienteId { get; set; }
        public Guid TipoTelefonoId { get; set; }
    }
}
