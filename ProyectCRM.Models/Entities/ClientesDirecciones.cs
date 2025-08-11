using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class ClientesDirecciones : EntityBase
    {
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Guid DireccionId { get; set; }
        public Direccion Direccion { get; set; }
        public Guid TipoDireccionId { get; set; }
        public TipoDireccion TipoDireccion { get; set; }
    }
}
