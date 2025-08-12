using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class Rol : EntityBase
    {
        public string Nombre { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
