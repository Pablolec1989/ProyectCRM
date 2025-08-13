using ProyectCRM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models.Entities
{
    public class Direccion : EntityBase
    {
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public string Provincia { get; set; }
        public Guid TipoDireccionId { get; set; }
        public TipoDireccion TipoDireccion { get; set; }
        public ICollection<DireccionCliente> Visitas { get; set; }
    }
}
