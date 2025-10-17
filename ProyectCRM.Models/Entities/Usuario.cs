using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public class Usuario : EntityBase
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public Guid AreaId { get; set; }
    public Area Area { get; set; }
    public ICollection<Llamado?> Llamados { get; set; }
    public ICollection<Mail?> Mails { get; set; }
    public ICollection<Seguimiento?> Seguimientos { get; set; }
    public ICollection<VisitaUsuario?> VisitasUsuarios { get; set; }

}
