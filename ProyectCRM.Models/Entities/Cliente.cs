using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Cliente : EntityBase
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public Guid? EmpresaId { get; set; }
    public virtual Empresa? Empresa { get; set; }
    public virtual ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();
    public virtual ICollection<Llamada> Llamada { get; set; } = new List<Llamada>();
    public virtual ICollection<Mail> Mail { get; set; } = new List<Mail>();
    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
    public virtual ICollection<TelefonosCliente> TelefonosClientes { get; set; } = new List<TelefonosCliente>();
}
