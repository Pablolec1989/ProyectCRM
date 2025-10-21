using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class CondicionIva : EntityBase
{
    public string? Nombre { get; set; }

    public virtual ICollection<Empresa?> Empresas { get; set; }
}
