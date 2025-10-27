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

    }
}
