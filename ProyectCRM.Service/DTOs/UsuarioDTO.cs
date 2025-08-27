using ProyectCRM.Models.Entities;
using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Service.DTOs
{
    public class UsuarioDTO : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Guid AreaId { get; set; }
        public AreaDTO Area { get; set; }
        public virtual ICollection<Llamada> Llamada { get; set; } = new List<Llamada>();
        public virtual ICollection<Mail> Mail { get; set; } = new List<Mail>();
        public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
        public virtual ICollection<VisitasUsuarios> Visitas { get; set; } = new List<VisitasUsuarios>();
    }
}
