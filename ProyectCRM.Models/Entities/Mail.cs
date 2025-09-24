using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Mail : EntityBase
{
    public string Detalle { get; set; }
    public Guid ClienteId { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid AsuntoDeContactoId { get; set; }
    public DateTime FechaMail { get; set; }

    public virtual AsuntosDeContacto AsuntoDeContacto { get; set; }
    public virtual Cliente Cliente { get; set; }
    public virtual Usuario? Usuario { get; set; }
}
