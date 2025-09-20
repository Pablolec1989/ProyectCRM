using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public class Empresa : EntityBase
{
    public string? RazonSocial { get; set; }
    public string? Cuit { get; set; }
    public string? Cuil { get; set; }
    public Guid? CondicionIvaId { get; set; }
    public Guid? RubroId { get; set; }
    public CondicionIva? CondicionIva { get; set; }
    public Rubro? Rubro { get; set; }
    public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
