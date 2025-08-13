using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs.TelefonoClienteDTO
{
    public class TelefonoClienteDTO : EntityBase
    {
        public string Numero { get; set; }
        public Guid TipoTelefonoId { get; set; }
        public List<TipoTelefono> TipoTelefono { get; set; }
        public Guid ClienteId { get; set; }
        public List<Cliente> Cliente { get; set; }
    }
}
