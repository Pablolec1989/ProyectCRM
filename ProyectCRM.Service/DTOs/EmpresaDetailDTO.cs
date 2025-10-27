using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class EmpresaDetailDTO : EmpresaDTO
    {
        public string Cuit { get; set; }
        public RubroDTO Rubro { get; set; }
        public CondicionIvaDTO CondicionIva { get; set; }

    }
}
