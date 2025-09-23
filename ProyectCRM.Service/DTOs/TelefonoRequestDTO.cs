using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class TelefonoRequestDTO
    {
        public string Numero { get; set; }
        public Guid ClienteId { get; set; }
        public Guid TipoTelefonoId { get; set; }
    }
}
