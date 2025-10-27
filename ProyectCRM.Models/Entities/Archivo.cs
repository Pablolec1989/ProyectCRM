using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public class Archivo : EntityBase
{
    public string NombreArchivo { get; set; }
    public string RutaArchivo { get; set; }
    public DateTime FechaSubida { get;}
    public Guid VisitaId { get; set; }
    public Visita Visita { get; set; }
}
