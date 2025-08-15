using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs
{
    public class DireccionUpdateCreateDTO : EntityBase
    {
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public string Provincia { get; set; }
        public Guid TipoDireccionId { get; set; }
    }
}
