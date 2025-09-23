using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public class Visita : EntityBase
{
    public DateOnly FechaProgramada { get; set; }
    public DateOnly FechaRealizada { get; set; }
    public string? Observaciones { get; set; }
    public Guid DireccionId { get; set; }
    public Direccion Direccion { get; set; }
    public IEnumerable<Archivo?> Archivos { get; set; }
    public IEnumerable<VisitasUsuarios?> VisitasUsuarios { get; set; }

}
