using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class TipoDireccion : EntityBase
{
    public string? Nombre { get; set; }
    public virtual ICollection<Direccion> Direcciones { get; set; }
}
