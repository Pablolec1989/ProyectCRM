using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Abstractions
{
    public abstract class EntityBaseWithName : EntityBase
    {
        public string Nombre { get; set; }
    }
}
