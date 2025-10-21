using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class AuthResponseDTO
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
