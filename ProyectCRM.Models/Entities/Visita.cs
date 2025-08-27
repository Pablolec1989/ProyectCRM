using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Visita : EntityBase
{
    public DateOnly? FechaProgramada { get; set; }

    public DateOnly? FechaRealizada { get; set; }

    public string? Observaciones { get; set; }

    public Guid? DireccionId { get; set; }

    public virtual Direccion? Direccion { get; set; }

    public virtual ICollection<Archivo> Archivos { get; set; } = new List<Archivo>();
    public virtual ICollection<VisitasUsuarios> Usuarios { get; set; } = new List<VisitasUsuarios>();   

}
