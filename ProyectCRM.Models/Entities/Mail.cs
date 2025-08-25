using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class Mail : EntityBase
    {
        public string Detalle { get; set; }
        public DateTime FechaMail { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
        public AsuntoDeContacto AsuntoDeContacto { get; set; }
        public Guid ClienteId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid AsuntoDeContactoId { get; set; }
    }
}
