using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.IvaCondicionDTOs;
using ProyectCRM.Service.DTOs.RubroDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs.EmpresaDTO
{
    public class EmpresaDTO : EntityBase
    {
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string CUIL { get; set; }
        public RubroDTO Rubro { get; set; }
        public CondicionIvaDTO CondicionIva { get; set; }
        public ClienteDTO Cliente { get; set; }
    }
}
