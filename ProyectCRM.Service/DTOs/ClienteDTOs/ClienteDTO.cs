using ProyectCRM.Models.Abstractions;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.ClientesDireccionesDTO;
using ProyectCRM.Service.DTOs.LlamadaDTO;
using ProyectCRM.Service.DTOs.MailDTO;
using ProyectCRM.Service.DTOs.SeguimientoDTOs;
using ProyectCRM.Service.DTOs.TelefonoClienteDTO;
using ProyectCRM.Service.DTOs.VisitaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.DTOs.ClienteDTO
{
    public class ClienteDTO : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public List<TelefonoCliente> Telefonos { get; set; }
        public Guid EmpresaId { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public List<ClienteDireccionDTO> Direcciones { get; set; } = [];
        public List<VisitaDTO> Visitas { get; set; } = [];
        public List<LlamadoDTO> Llamados { get; set; }
        public List<MailDTO> Mails { get; set; }
        public List<SeguimientoDTO> Seguimientos { get; set; }

    }
}
