using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ProyectCRM.Service.DTOs
{
    public class EmpresaDTO : EntityBase
    {
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string CUIL { get; set; }
        public Guid ClienteId { get; set; }
        public Guid RubroId { get; set; }
        public Guid CondicionIvaId { get; set; }
        public ClienteDTO Cliente { get; set; }
        public RubroDTO Rubro { get; set; }
        public CondicionIvaDTO CondicionIva { get; set; }
    }
}
