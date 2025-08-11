using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class DireccionCliente : EntityBase
    {
        public Guid ClienteId { get; set; }
        public Guid DireccionId { get; set; }
        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Direccion Direccion { get; set; } = null!;
    }
}
