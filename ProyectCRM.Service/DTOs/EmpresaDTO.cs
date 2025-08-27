using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ProyectCRM.Models.Service.DTOs
{
    public class EmpresaDTO : EntityBase
    {
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string Cuil { get; set; }
        public Guid ClienteId { get; set; }
        public Guid RubroId { get; set; }
        public Guid CondicionIvaId { get; set; }
        public Guid DireccionId { get; set; }
        public ClienteDTO Cliente { get; set; }
        public RubroDTO Rubro { get; set; }
        public CondicionIvaDTO CondicionIva { get; set; }
        public ICollection<DireccionDTO> Direcciones { get; set; }
    }
}
