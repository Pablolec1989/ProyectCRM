using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Llamado : EntityBase
{
    public Guid ClienteId { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid? AreaId { get; set; }

    public string Detalle { get; set; } = null!;
    public DateTime FechaLlamado { get; set; }
    public Guid AsuntoDeContactoId { get; set; }
    public virtual Area? Area { get; set; }
    public virtual AsuntosDeContacto AsuntoDeContacto { get; set; } = null!;
    public virtual Cliente? Cliente { get; set; } = null!;
    public virtual Usuario? Usuario { get; set; } = null!;
}
