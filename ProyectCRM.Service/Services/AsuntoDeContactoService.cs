using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.AsuntoDeContactoDTO;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class AsuntoDeContactoService : ServiceBase<AsuntoDeContactoDTO, AsuntoDeContactoUpdateCreateDTO, AsuntoDeContacto>, IAsuntoDeContactoService
    {
        public AsuntoDeContactoService(IAsuntoDeContactoMapper mapper, 
            IAsuntoDeContactoRepository repository) : base(mapper, repository)
        {
        }
    }
}
