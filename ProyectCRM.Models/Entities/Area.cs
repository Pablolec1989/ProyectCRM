using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Area : EntityBase
{
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Llamado> Llamados { get; set; } = new List<Llamado>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
