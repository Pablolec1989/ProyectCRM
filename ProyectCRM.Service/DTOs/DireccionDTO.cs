using ProyectCRM.Models.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class DireccionDTO
    {
        public string Ciudad { get; set; }
        public TipoDireccionDTO TipoDireccion { get; set; }
    }
}
