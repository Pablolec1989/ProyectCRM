using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.AuthService
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public DateTime FechaExpiracion { get; set; }
    }
}
