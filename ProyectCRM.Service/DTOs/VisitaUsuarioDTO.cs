using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class VisitaUsuarioDTO : EntityBase
    {
        public Guid UsuarioId { get; set; }
        public UsuarioDTO? Usuario { get; set; }
        public Guid VisitaId { get; set; }
        public VisitaDTO? Visita { get; set; }
    }
}
