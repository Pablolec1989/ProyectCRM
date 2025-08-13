using ProyectCRM.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace ProyectCRM.Models.Entities
{
    public class Area : EntityBase
    {
        public string Nombre { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<Llamado> Llamados { get; set; }
    }
}
