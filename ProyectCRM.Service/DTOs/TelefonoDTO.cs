using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class TelefonoDTO : EntityBase
    {
        public string Numero { get; set; } = null!;
        public TipoTelefonoDTO TipoTelefono { get; set; } = null!;
        public Guid ClienteId { get; set; }
        public ClienteDTO Cliente { get; set; } = null!;
    }
}
