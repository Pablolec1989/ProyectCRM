using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Models
{
    public class Area
    {
        [Required]
        public int id { get; set; }
        [MaxLength(50)]
        public string nombre { get; set; } = string.Empty;
    }
}
