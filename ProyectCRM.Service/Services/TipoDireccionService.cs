using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.TipoDireccionDTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class TipoDireccionService : ServiceBase<TipoDireccionDTO,TipoDireccionCreateDTO,TipoDireccion>, ITipoDireccionService
    {
        public TipoDireccionService(IMapperBase<TipoDireccionDTO, TipoDireccionCreateDTO, TipoDireccion> mapper, 
            ITipoDireccionRepository repository) : base(mapper, repository)
        {
        }
    }
}
