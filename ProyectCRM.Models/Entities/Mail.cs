using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class Mail : EntityBase
{
    public string Detalle { get; set; }
    public Guid ClienteId { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid? AreaId { get; set; }
    public Guid AsuntoDeContactoId { get; set; }
    public DateTime FechaMail { get; set; }

    public AsuntosDeContacto AsuntoDeContacto { get; set; }
    public Cliente Cliente { get; set; }
    public Usuario? Usuario { get; set; }
    public Area? Area { get; set; }
}
