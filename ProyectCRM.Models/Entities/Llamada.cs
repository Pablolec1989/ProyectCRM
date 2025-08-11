using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class Llamada : EntityBase
    {
        public string Detalle { get; set; }
        public DateTime FechaLlamado { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Guid AsuntoDeContactoId { get; set; }
        public AsuntoDeContacto AsuntoDeContacto { get; set; }


    }
}
