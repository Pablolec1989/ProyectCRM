using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class VisitaUsuarioRequestDTO : EntityBase
    {
        public Guid VisitaId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
