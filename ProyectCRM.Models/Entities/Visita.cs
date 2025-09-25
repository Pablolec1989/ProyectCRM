using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public class Visita : EntityBase
{
    public string? Observaciones { get; set; } = string.Empty;
    public Guid ClienteId { get; set; }
    public Guid DireccionId { get; set; }
    public Cliente Cliente { get; set; }
    public Direccion Direccion { get; set; }

    public ICollection<Archivo?> Archivos { get; set; } = [];
    public ICollection<VisitaUsuario> VisitasUsuarios { get; set; } = [];
    public DateTime FechaProgramada { get; set; }
    public DateTime FechaRealizada { get; set; }

}
