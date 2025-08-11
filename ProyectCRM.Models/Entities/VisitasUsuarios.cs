using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class VisitasUsuarios : EntityBase
    {
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Guid VisitaId { get; set; }
        public Visita Visita { get; set; }
    }
}
