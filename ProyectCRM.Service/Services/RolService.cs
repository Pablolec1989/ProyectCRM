using FluentValidation;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs.RolDTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class RolService : ServiceBase<RolDTO, RolUpdateCreateDTO, Rol>, IRolService
    {
        public RolService(IRolMapper mapper, IRolRepository repository, IValidator<Rol> validator) 
            : base(mapper, repository, validator)
        {
        }
    }
}
