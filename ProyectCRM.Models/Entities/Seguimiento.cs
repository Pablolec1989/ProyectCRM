using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Seguimiento : EntityBase
{
    public string Titulo { get; set; }
    public string Detalle { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid ClienteId { get; set; }
    public Guid? AreaId { get; set; }

    public virtual Usuario Usuario { get; set; }
    public Area? Area { get; set; } 
    public virtual Cliente Cliente { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}
