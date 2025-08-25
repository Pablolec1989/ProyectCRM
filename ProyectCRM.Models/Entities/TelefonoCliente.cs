using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class TelefonoCliente : EntityBase
    {
        public string Numero { get; set; }
        public Guid TipoTelefonoId { get; set; }
        public Guid ClienteId { get; set; }
        public TipoTelefono TipoTelefono { get; set; }
        public Cliente Cliente { get; set; }
    }
}
