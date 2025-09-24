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
    public virtual ICollection<Direccion> Direcciones { get; set; } = [];
    public virtual ICollection<Llamado> Llamados { get; set; } = [];
    public virtual ICollection<Mail> Mails { get; set; } = [];
    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = [];
    public virtual ICollection<Telefono> Telefonos { get; set; } = [];
    public virtual ICollection<Visita> Visitas { get; set; } = [];
}
