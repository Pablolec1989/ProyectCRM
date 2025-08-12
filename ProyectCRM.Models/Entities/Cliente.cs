using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class Cliente : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Guid TelefonoClienteId { get; set; }
        public TelefonoCliente Telefono { get; set; }
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public ICollection<Direccion> Direcciones { get; set; } = [];
        public ICollection<Visita> Visitas { get; set; } = [];

    }
}
