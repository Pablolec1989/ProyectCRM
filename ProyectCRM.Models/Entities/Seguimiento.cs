using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class Seguimiento : EntityBase
    {
        public string Titulo { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
