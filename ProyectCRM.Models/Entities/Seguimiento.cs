using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Seguimiento : EntityBase
{
    public Guid? UsuarioId { get; set; }

    public Guid? ClienteId { get; set; }

    public string? Detalle { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public string? Titulo { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
