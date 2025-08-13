using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class TipoTelefono : EntityBase
    {
        public string Nombre { get; set; }
        public ICollection<TelefonoCliente> TelefonosClientes { get; set; }
    }
}
