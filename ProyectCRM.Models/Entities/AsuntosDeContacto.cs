using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class AsuntosDeContacto : EntityBase
{
    public string Nombre { get; set; }
    public List<Mail?> Mail { get; set; } = [];
    public List<Llamado?> Llamados { get; set; } = [];

}
