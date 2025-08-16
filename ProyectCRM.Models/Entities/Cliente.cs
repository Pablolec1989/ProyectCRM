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
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public ICollection<Direccion> Direccion { get; set; } = [];
        public ICollection<Visita> Visitas { get; set; }
        public ICollection<TelefonoCliente> TelefonoCliente { get; set; } = [];
        public ICollection<Llamado> Llamados { get; set; } = [];
        public ICollection<Mail> Mails { get; set; } = [];
        public ICollection<Seguimiento> Seguimientos { get; set; } = [];
        

    }
}
