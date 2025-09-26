using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Area : EntityBase
{
    public string Nombre { get; set; }
    public List<Llamado?> Llamados { get; set; } = [];
    public List<Mail?> Mails { get; set; } = [];
    public List<Seguimiento?> Seguimientos { get; set; } = [];
    public List<Usuario?> Usuarios { get; set; } = [];
}
