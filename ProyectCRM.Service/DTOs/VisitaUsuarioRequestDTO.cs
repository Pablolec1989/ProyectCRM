using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class VisitaUsuarioRequestDTO : EntityBase
    {
        public Guid VisitaId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
