using ProyectCRM.Models.Entities.Abstractions;
using ProyectCRM.Models.Entities;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Usuario : EntityBase
{
    public string Nombre { get; set; }

    public string Apellido { get; set; }
    public string Password { get; set; }

    public Guid? RolId { get; set; }

    public Guid? AreaId { get; set; }
    public virtual Rol? Rol { get; set; }
    public virtual Area? Area { get; set; }
    public virtual ICollection<Llamada> Llamada { get; set; } = new List<Llamada>();
    public virtual ICollection<Mail> Mail { get; set; } = new List<Mail>();
    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
    public virtual ICollection<VisitasUsuarios> Visitas { get; set; } = new List<VisitasUsuarios>();


}
