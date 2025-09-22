using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Mail : EntityBase
{
    public Guid ClienteId { get; set; }

    public DateTime? FechaMail { get; set; }

    public Guid? UsuarioId { get; set; }

    public string? Detalle { get; set; }

    public Guid? AsuntoId { get; set; }

    public virtual AsuntosDeContacto? AsuntoDeContacto { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
