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
    public Empresa? Empresa { get; set; }
    public ICollection<Direccion> Direcciones { get; set; } = [];
    public ICollection<Llamado> Llamados { get; set; } = [];
    public ICollection<Mail> Mails { get; set; } = [];
    public ICollection<Seguimiento> Seguimientos { get; set; } = [];
    public ICollection<Telefono> Telefonos { get; set; } = [];
    public ICollection<Visita> Visitas { get; set; } = [];
}
