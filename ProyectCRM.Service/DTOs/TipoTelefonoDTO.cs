using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class TipoTelefonoDTO : EntityBase
    {
        public string Nombre { get; set; }
    }
}
