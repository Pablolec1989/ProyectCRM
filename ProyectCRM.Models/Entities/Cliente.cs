using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Cliente : EntityBase
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public Guid? EmpresaId { get; set; }
    public virtual Empresa? Empresa { get; set; }
    public virtual ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();
    public virtual ICollection<Llamado> Llamados { get; set; } = new List<Llamado>();
    public virtual ICollection<Mail> Mail { get; set; } = new List<Mail>();
    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
    public virtual ICollection<Telefonos> TelefonosClientes { get; set; } = new List<Telefonos>();
}
