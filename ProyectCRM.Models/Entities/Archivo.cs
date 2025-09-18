using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public class Archivo : EntityBase
{
    public string NombreArchivo { get; set; }
    public string RutaArchivo { get; set; }
    public DateOnly FechaSubida { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public Guid VisitaId { get; set; }
    public Visita Visita { get; set; }
}
