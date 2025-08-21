using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class EmpresaRequestDTO : EntityBase
    {
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string CUIL { get; set; }
        public Guid CondicionIvaId { get; set; }
        public Guid RubroId { get; set; }

    }
}
