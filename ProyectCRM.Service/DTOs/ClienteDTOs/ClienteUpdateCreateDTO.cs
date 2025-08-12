using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs.ClienteDTO
{
    public class ClienteUpdateCreateDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Guid TelefonoClienteId { get; set; }
        public Guid EmpresaId { get; set; }
        public ICollection<Guid> DireccionesIds { get; set; } = [];
        public ICollection<Guid> VisitasIds { get; set; } = [];

    }
}
