using ProyectCRM.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace ProyectCRM.Models.Entities
{
    public class Area : EntityBase
    {
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
    }
}
