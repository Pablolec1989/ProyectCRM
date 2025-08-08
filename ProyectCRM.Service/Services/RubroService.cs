using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.RubroDTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class RubroService : ServiceBase<RubroDTO, RubroCreateDTO, Rubro>, IRubroService
    {
        public RubroService(IMapperBase<RubroDTO, RubroCreateDTO, Rubro> mapper, 
            IRubroRepository repository) : base(mapper, repository)
        {
            
        }
    }
}
