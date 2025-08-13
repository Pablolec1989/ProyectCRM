using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs.LlamadaDTO
{
    public class LlamadoDTO : EntityBase
    {
        public string Detalle { get; set; }
        public DateTime FechaLlamado { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Guid AsuntoDeContactoId { get; set; }
        public Models.Entities.AsuntoDeContacto AsuntoDeContacto { get; set; }

    }
}
