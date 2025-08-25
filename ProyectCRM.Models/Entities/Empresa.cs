using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class Empresa : EntityBase
    {
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string Cuil { get; set; }
        public Guid ClienteId { get; set; }
        public Guid RubroId { get; set; }
        public Guid CondicionIvaId { get; set; }
        public Cliente Cliente { get; set; }
        public CondicionIva CondicionIva { get; set; }
        public Rubro Rubro { get; set; }

    }
}
