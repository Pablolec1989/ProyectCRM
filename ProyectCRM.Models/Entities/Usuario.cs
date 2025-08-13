using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class Usuario : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public Guid RolId { get; set; }
        public Rol Rol { get; set; }
        public Guid AreaId { get; set; }
        public Area Area { get; set; }
        public ICollection<Llamado> Llamados { get; set; }
        public ICollection<Mail> Mails { get; set; }
        public ICollection<Seguimiento> Seguimientos { get; set; }
        public ICollection<VisitaUsuario> VisitasUsuarios { get; set; }
    }
}
