using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Empresa : EntityBase
{
    public string? RazonSocial { get; set; }

    public string? Cuit { get; set; }

    public string? Cuil { get; set; }

    public Guid? CondicionIvaId { get; set; }

    public Guid? RubroId { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual CondicionIva? CondicionIva { get; set; }

    public virtual Rubro? Rubro { get; set; }
}
