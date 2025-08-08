using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public abstract class BaseReadUpdateDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }
}
