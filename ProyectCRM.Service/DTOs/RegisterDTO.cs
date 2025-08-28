using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class RegisterDTO
    {
        public string Apellido { get; set; }
        public string Password { get; set; }
        public Guid RolId { get; set; }
    }
}
