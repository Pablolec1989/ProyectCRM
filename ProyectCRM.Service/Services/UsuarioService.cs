using FluentValidation;
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
    public class UsuarioService : ServiceBase<UsuarioDTO, UsuarioUpdateCreateDTO, Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioMapper mapper, IUsuarioRepository repository, IValidator<Usuario> validator) : base(mapper, repository, validator)
        {
        }
    }
}
