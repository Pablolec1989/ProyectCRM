using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Rol : EntityBase
{
    public string Nombre { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
