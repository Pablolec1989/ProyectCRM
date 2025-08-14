using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class TelefonoClienteDTO : EntityBase
    {
        public string Numero { get; set; }
        public ICollection<TipoTelefonoDTO> TipoTelefono { get; set; }
        public ICollection<ClienteDTO> Cliente { get; set; }
    }
}
