using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Direccion : EntityBase
{
    public string? CodigoPostal { get; set; }

    public Guid? TipoDireccionId { get; set; }

    public string? Calle { get; set; }

    public int? Numero { get; set; }

    public string? Ciudad { get; set; }

    public string? Provincia { get; set; }

    public Guid? ClienteId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual TipoDireccion? TipoDireccion { get; set; }

    public virtual ICollection<Visita> Visita { get; set; } = new List<Visita>();
}
