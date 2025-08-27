using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Area : EntityBase
{
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Llamada> Llamada { get; set; } = new List<Llamada>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
