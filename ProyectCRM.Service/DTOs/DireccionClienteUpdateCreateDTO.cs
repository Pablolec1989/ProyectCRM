using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class DireccionClienteUpdateCreateDTO : EntityBase
    {
        public Guid ClienteId { get; set; }
        public Guid DireccionId { get; set; }

    }
}
