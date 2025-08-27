using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Archivo : EntityBase
{
    public Guid? VisitaId { get; set; }

    public string? NombreArchivo { get; set; }

    public string? RutaArchivo { get; set; }

    public DateOnly? FechaSubida { get; set; }

    public virtual Visita? Visita { get; set; }
}
