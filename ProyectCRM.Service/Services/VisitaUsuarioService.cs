using FluentValidation;
using ProyectCRM.Data;
using ProyectCRM.Data.Interfaces;
using ProyectCRM.Models.Entities;
using ProyectCRM.Service.DTOs;
using ProyectCRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCRM.Service.Services
{
    public class VisitaUsuarioService : ServiceBase<VisitaUsuarioDTO, VisitaUsuarioUpdateCreateDTO, VisitaUsuario>, IVisitaUsuarioService
    {
        public VisitaUsuarioService(IVisitaUsuarioMapper mapper, 
            IVisitaUsuarioRepository repository, 
            IValidator<VisitaUsuario> validator) : base(mapper, repository, validator)
        {
        }
    }
}
