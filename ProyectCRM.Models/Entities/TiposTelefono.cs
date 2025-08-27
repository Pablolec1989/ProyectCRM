using ProyectCRM.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace ProyectCRM.Models.Entities;

public partial class TiposTelefono : EntityBase
{
    public string Nombre { get; set; } = null!;

    public virtual ICollection<TelefonosCliente> TelefonosClientes { get; set; } = new List<TelefonosCliente>();
}
