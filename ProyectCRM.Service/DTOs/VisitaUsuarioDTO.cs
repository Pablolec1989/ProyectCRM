using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class VisitaUsuarioDTO : EntityBase
    {
        public Guid UsuarioId { get; set; }
        public Guid VisitaId { get; set; }

        //Prop de nav
        public UsuarioDTO? Usuario { get; set; }
        public VisitaDTO? Visita { get; set; }
    }
}
