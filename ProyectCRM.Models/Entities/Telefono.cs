using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Telefono : EntityBase
{
    public string? Numero { get; set; }
    public Guid TipoTelefonoId { get; set; }
    public Guid ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; }
    public virtual TiposTelefono TipoTelefono { get; set; }
}
