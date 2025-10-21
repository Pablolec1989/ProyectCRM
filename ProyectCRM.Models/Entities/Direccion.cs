using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Direccion : EntityBase
{
    public string CodigoPostal { get; set; }
    public string Calle { get; set; }
    public int Numero { get; set; }
    public string Ciudad { get; set; }
    public string Provincia { get; set; }
    public Guid ClienteId { get; set; }
    public Guid TipoDireccionId { get; set; }

    public Cliente Cliente { get; set; }
    public TipoDireccion TipoDireccion { get; set; }
    public ICollection<Visita?> Visitas { get; set; } = [];
}
