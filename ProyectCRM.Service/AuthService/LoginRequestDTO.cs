using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.AuthService
{
    public class LoginRequestDTO
    {
        public string Apellido { get; set; }
        public string Password { get; set; }
    }
}
