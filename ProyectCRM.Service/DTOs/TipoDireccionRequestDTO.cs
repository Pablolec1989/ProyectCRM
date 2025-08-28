using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class TipoDireccionRequestDTO : EntityBase
    {
        public string Nombre { get; set; }
    }
}
